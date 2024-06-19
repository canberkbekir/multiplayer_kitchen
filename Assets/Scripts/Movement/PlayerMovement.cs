using ECM2;
using Input;
using Mirror;
using UnityEngine;

namespace Movement
{
    public class PlayerMovement : NetworkBehaviour
    {
        [Header("Dependencies")] [SerializeField]
        private InputObject _inputObject;

        [SerializeField] private Character _character;
        [SerializeField] private GameObject _cameraPivot;

        [Header("Movement Settings")] [SerializeField]
        private float _movementSpeed = 5f;

        [SerializeField] private float _jumpForce = 5f;

        private Vector2 _movementInput;
        private bool _isJumping;
        private Camera _playerCamera;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _character.camera = Camera.main;
        }

        private void Start()
        {
            _inputObject.MoveEvent += OnMove;
            _inputObject.MoveCanceledEvent += OnMoveCanceled;

            _inputObject.JumpEvent += OnJump;
            _inputObject.JumpCanceledEvent += OnJumpCanceled;
        }

        [Client]
        private void Update()
        {
            if (!isOwned)
            {
                return;
            }

            Move();
            Jump();
        }

        private void Move()
        {
            Vector3 movementDirection = Vector3.zero;

            movementDirection += Vector3.right * _movementInput.x;
            movementDirection += Vector3.forward * _movementInput.y;


            if (_character.camera)
            {
                movementDirection
                    = movementDirection.relativeTo(_character.cameraTransform) * (_movementSpeed * Time.deltaTime);
            }

            _character.SetMovementDirection(movementDirection);
        }

        private void Jump()
        {
            if (_isJumping)
                _character.Jump();
            else
                _character.StopJumping();
        }

        #region Events

        private void OnJumpCanceled()
        {
            _isJumping = false;
        }

        private void OnJump()
        {
            _isJumping = true;
        }

        private void OnMoveCanceled()
        {
            _movementInput = Vector2.zero;
        }

        private void OnMove(Vector2 obj)
        {
            _movementInput = obj;
        }

        #endregion
    }
}
