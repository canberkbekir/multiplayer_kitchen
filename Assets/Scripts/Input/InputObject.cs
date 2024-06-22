using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    [CreateAssetMenu(fileName = "InputObject", menuName = "Input/InputObject")]
    public class InputObject : ScriptableObject, PlayerInput.IGameplayActions, PlayerInput.IUIActions
    {
        private PlayerInput _playerInput;

        private void OnEnable()
        {
            if (_playerInput == null)
            {
                _playerInput = new PlayerInput();

                _playerInput.Gameplay.SetCallbacks(this);
                _playerInput.UI.SetCallbacks(this);

                SetGameplay();
            }
        }

        public event Action<Vector2> MoveEvent;
        public event Action MoveCanceledEvent;

        public event Action JumpEvent;
        public event Action JumpCanceledEvent;

        public event Action InteractEvent;
        public event Action InteractCanceledEvent;

        public event Action<Vector2> LookEvent;
        public event Action LookCanceledEvent;

        public void SetGameplay()
        {
            _playerInput.Gameplay.Enable();
            _playerInput.UI.Disable();
        }

        public void SetUI()
        {
            _playerInput.UI.Enable();
            _playerInput.Gameplay.Disable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    MoveEvent?.Invoke(context.ReadValue<Vector2>());
                    break;
                case InputActionPhase.Canceled:
                    MoveCanceledEvent?.Invoke();
                    break;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    JumpEvent?.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    JumpCanceledEvent?.Invoke();
                    break;
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    LookEvent?.Invoke(context.ReadValue<Vector2>());
                    break;
                case InputActionPhase.Canceled:
                    LookCanceledEvent?.Invoke();
                    break;
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    InteractEvent?.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    InteractCanceledEvent?.Invoke();
                    break;
            }
        }

        #region UI

        public void OnPause(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResume(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnUp(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnDown(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnLeft(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnRight(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
