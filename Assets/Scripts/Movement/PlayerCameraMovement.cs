using System;
using ECM2;
using Input;
using Mirror;
using UnityEngine;

namespace Movement
{
    public sealed class PlayerCameraMovement : NetworkBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Vector2 _sensitivity = new Vector2(2.0f, 2.0f);
        [SerializeField] private float _minPitch = -80.0f;
        [SerializeField] private float _maxPitch = 80.0f;

        [Header("Dependencies")] [SerializeField]
        Transform _cameraPivot;

        [SerializeField] Character _character;
        [SerializeField] InputObject _inputObject;

        private float _cameraTargetPitch;
        private Vector2 _lookInput;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _character.camera = Camera.main;
            _inputObject.LookEvent += OnLook;
            _inputObject.LookCanceledEvent += OnLookCanceled;
        }


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            _character.SetRotationMode(Character.RotationMode.None);
        }

        private void Update()
        {
            if(!isOwned) {return;}
            CameraFollow();
            AddControlYawInput(_lookInput.x * _sensitivity.x);
            AddControlPitchInput(_lookInput.y * _sensitivity.y, _minPitch, _maxPitch);
        }

        #region Events

        private void OnLookCanceled()
        {
            _lookInput = Vector2.zero;
        }

        private void OnLook(Vector2 obj)
        {
            _lookInput = obj;
        }

        #endregion

        private void AddControlYawInput(float value)
        {
            if (value != 0.0f)
                _character.AddYawInput(value);
        }


        private void AddControlPitchInput(float value, float minValue = -80.0f, float maxValue = 80.0f)
        {
            if (value == 0.0f)
                return;

            _cameraTargetPitch = MathLib.ClampAngle(_cameraTargetPitch + value, minValue, maxValue);
            _cameraPivot.transform.localRotation = Quaternion.Euler(-_cameraTargetPitch, 0.0f, 0.0f);
        }

        private void CameraFollow()
        {
            if (_character.camera)
            {
                _character.camera.transform.position = _cameraPivot.position;
                _character.camera.transform.rotation = _cameraPivot.rotation;
            }
        }
    }
}
