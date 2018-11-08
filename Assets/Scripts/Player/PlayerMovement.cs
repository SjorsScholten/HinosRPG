using System;
using UnityEngine;

namespace Player {
	
	public enum PlayerStance{Default, Running, Crouched, Prone}
	
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerMovement : MonoBehaviour {
		private Transform _transform;
		private Transform _camera;
		private Rigidbody _rb;
		private CapsuleCollider _collider;
	
		private void Start () {
			_transform = GetComponent<Transform>();
			_camera = Camera.main.transform;
			_rb = GetComponent<Rigidbody>();
			_collider = GetComponentInChildren<CapsuleCollider>();
			_distToGround = _collider.bounds.extents.y;
		}

		private void Update() {
			// get input
			var horizontal = Input.GetAxisRaw("Horizontal");
			var vertical = Input.GetAxisRaw("Vertical");
			var direction = new Vector2(horizontal, vertical).normalized;
			
			if(Input.GetButtonDown("Crouch")) SetPlayerStanceCrouched();
			if (direction != Vector2.zero) Rotate(direction);
			Move(direction);
		}

		private void LateUpdate() {
			if (Input.GetButton("Jump")) Jump();
		}
		
		private float GetModifiedSmoothTime(float smoothTime) {
			if (IsGrounded) return smoothTime;
			if (Math.Abs(_airControlPercent) < 0) return float.MaxValue;
			return smoothTime / _airControlPercent;
		}

		#region Moving Mechanics

		[Header("Walk properties")]
		[SerializeField] private float _walkSpeed = 2;
		[SerializeField] private float _speedSmoothTime = 0.1f;
		private float _speedSmoothVelocity;
		private float _currentSpeed;
	
		private void Move(Vector2 direction) {
			var targetSpeed = _walkSpeed * SpeedModifier * direction.magnitude;
			_currentSpeed = Mathf.SmoothDamp(_currentSpeed, targetSpeed, ref _speedSmoothVelocity, GetModifiedSmoothTime(_speedSmoothTime));
			var velocity = _transform.forward * _currentSpeed;
			_rb.MovePosition(_transform.position + velocity * Time.deltaTime);
			_currentSpeed = new Vector2(_rb.velocity.x, _rb.velocity.z).magnitude;
		}

		#endregion

		#region Turn Mechanics

		[Header("Turn properties")]
		[SerializeField] private float _turnSmoothTime = 0.2f;
		private float _turnSmoothVelocity;
	
		private void Rotate(Vector2 direction) {
			var targetRotation = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + _camera.eulerAngles.y;
			var rotationSmooth = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetRotation, ref _turnSmoothVelocity, GetModifiedSmoothTime(_turnSmoothTime));
			_rb.MoveRotation(Quaternion.Euler((Vector3.up * rotationSmooth)));
		}

		#endregion
		
		#region Jumping Mechanics

		[Header("Jump properties")]
		[SerializeField] private float _jumpHeight = 3f;
		[SerializeField][Range(0, 1)] private float _airControlPercent;
		private float _distToGround;

		private void Jump() {
			if (!IsGrounded) return;
			var gravity = Physics.gravity.y;
			var initialVelocity = -2 * gravity * _jumpHeight;
			_rb.AddForce(Vector3.up * Mathf.Sqrt(initialVelocity), ForceMode.Impulse);
		}
		
		private bool IsGrounded {
			get {
				var ray = new Ray(_transform.position + Vector3.up * _distToGround, -Vector3.up);
				return Physics.Raycast(ray, _distToGround + 0.1f);
			}
		}

		#endregion

		#region Player Stance Mechanics
		
		private PlayerStance _currentStance = PlayerStance.Default;
		
		[Header("Speed properties")]
		[SerializeField] private float _defaultSpeedModifier = 1;
		[SerializeField] private float _defaultHeight = 2f;
		
		private void SetPlayerStanceDefault() {
			_collider.height = _defaultHeight;
			_collider.center = new Vector3(0, _defaultHeight/2, 0);
			_currentStance = PlayerStance.Default;
		}
		
		[Space]
		[SerializeField] private float _runSpeedModifier = 2;
		
		private void SetPlayerStanceRunning() {
			_currentStance = PlayerStance.Running;
		}
		
		[Space]
		[SerializeField] private float _crouchSpeedModifier = 0.75f;
		[SerializeField] private float _crouchedHeight = 1f;
		
		private void SetPlayerStanceCrouched() {
			if (_currentStance == PlayerStance.Crouched) {
				SetPlayerStanceDefault();
				return;
			}

			_collider.height = _crouchedHeight;
			_collider.center = new Vector3(0, _crouchedHeight/2, 0);
			_currentStance = PlayerStance.Crouched;
		}
		
		[Space]
		[SerializeField] private float _proneSpeedModifier = 0.5f;
		[SerializeField] private float _proneHeight = 0.25f;

		private void SetStanceToProne() {
			_currentStance = PlayerStance.Prone;
		}
		

		private float SpeedModifier {
			get {
				switch (_currentStance) {
					case PlayerStance.Default: return _defaultSpeedModifier;
					case PlayerStance.Running: return _runSpeedModifier;
					case PlayerStance.Crouched: return _crouchSpeedModifier;
					case PlayerStance.Prone: return _proneSpeedModifier;
					default: throw new ArgumentOutOfRangeException();
				}
			}
		}

		#endregion

	}
}
