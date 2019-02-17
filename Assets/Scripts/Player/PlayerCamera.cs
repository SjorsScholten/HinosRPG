using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player {
	public class PlayerCamera : MonoBehaviour {
		[Header("Camera Settings")]
		[SerializeField] private bool _lockCursor;
		[SerializeField] private float _offset = 2;
		[SerializeField] private float _mouseSensitivity = 10;
		[SerializeField] private Vector2 _pitchClamp = new Vector2(-40, 85);
		
		[SerializeField] private float _rotationSmoothTime = 0.12f;
		private Vector3 _rotationSmoothVelocity;
		private Vector3 _currentRotation;
		
		[Header("Pivot Settings")]
		[SerializeField] private Transform _pivotTarget;

		[Header("Target Settings")] 
		[SerializeField] private Transform _zTarget;
		private bool _isTargeting = false;

		private float _yaw;
		private float _pitch;

		private void Start() {
			if (!_lockCursor) return;
			
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void Update() {
			if (Input.GetButtonDown("Targeting") && !_isTargeting) {
				_isTargeting = true;
			}
		}

		private void LateUpdate() {
			var motion = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			if (!_isTargeting) {
				RotateAroundPivot(motion.x * _mouseSensitivity, motion.y * _mouseSensitivity);
			}
			else {
				LookAtTarget();
			}
			
			
		}

		private void RotateAroundPivot(float x, float y) {
			if (_isTargeting) _isTargeting = false;
			
			_yaw += x;
			_pitch -= y;
			
			_pitch = Mathf.Clamp(_pitch, _pitchClamp.x, _pitchClamp.y);

			_currentRotation = Vector3.SmoothDamp(_currentRotation, new Vector3(_pitch, _yaw), ref _rotationSmoothVelocity, _rotationSmoothTime);

			transform.eulerAngles = _currentRotation;
			transform.position = _pivotTarget.position - transform.forward * _offset;
		}

		private void LookAtTarget() {
			throw new NotImplementedException();
		}
	}
}
