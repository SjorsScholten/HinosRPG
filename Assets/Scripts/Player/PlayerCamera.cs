using UnityEngine;
using UnityEngine.Serialization;

namespace Player {
	public class PlayerCamera : MonoBehaviour {
		[SerializeField] private bool _lockCursor;
		[SerializeField] private Transform _target;
		[SerializeField] private float _offset = 2;
		[SerializeField] private float _mouseSensitivity = 10;
		[SerializeField] private Vector2 _pitchClamp = new Vector2(-40, 85);

		[SerializeField] private float _rotationSmoothTime = 0.12f;
		private Vector3 _rotationSmoothVelocity;
		private Vector3 _currentRotation;

		private float _yaw;
		private float _pitch;

		private void Start() {
			if (!_lockCursor) return;
			
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void LateUpdate() {
			_yaw += Input.GetAxis("Mouse X") * _mouseSensitivity;
			_pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity;
			_pitch = Mathf.Clamp(_pitch, _pitchClamp.x, _pitchClamp.y);

			_currentRotation = Vector3.SmoothDamp(_currentRotation, new Vector3(_pitch, _yaw), ref _rotationSmoothVelocity, _rotationSmoothTime);

			transform.eulerAngles = _currentRotation;
			transform.position = _target.position - transform.forward * _offset;
		}
	}
}
