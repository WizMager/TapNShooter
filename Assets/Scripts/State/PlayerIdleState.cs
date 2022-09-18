using UnityEngine;
using UnityEngine.InputSystem;

namespace State
{
    public class PlayerIdleState : BaseState
    {
        private readonly Transform _playerTransform;
        private readonly Transform _playerSpawnPosition;
        
        public PlayerIdleState(Animator animator, IStateSwitcher stateSwitcher, InputActions inputActions, Transform playerTransform, Transform playerSpawnPosition) : base(animator, stateSwitcher, inputActions)
        {
            _playerTransform = playerTransform;
            _playerSpawnPosition = playerSpawnPosition;
        }
        
        public override void Start()
        {
            Debug.Log("Start idle");
            _playerTransform.SetPositionAndRotation(_playerSpawnPosition.position, _playerSpawnPosition.rotation);
            _inputActions.Player.Touch.performed += OnTouchHandler;
            //TODO: start idle animation
        }

        private void OnTouchHandler(InputAction.CallbackContext obj)
        {
            _stateSwitcher.SwitchState<PlayerRunState>();
        }

        public override void Stop()
        {
            Debug.Log("Stop idle");
            _inputActions.Player.Touch.performed -= OnTouchHandler;
            //TODO: stop idle animation
        }
    }
}