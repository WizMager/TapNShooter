using UnityEngine;
using UnityEngine.InputSystem;

namespace State
{
    public class PlayerShootState : BaseState
    {
        public PlayerShootState(Animator animator, IStateSwitcher stateSwitcher, InputActions inputActions) : base(animator, stateSwitcher, inputActions)
        {
        }
        
        public override void Start()
        {
            Debug.Log("Start shoot");
            _inputActions.Player.Touch.performed += OnTouchHandler;
            //TODO: start idle animation because wait for shoot input
        }

        private void OnTouchHandler(InputAction.CallbackContext obj)
        {
            _stateSwitcher.SwitchState<PlayerRunState>();
            var tapPosition = _inputActions.Player.TouchPosition.ReadValue<Vector2>();
            //TODO: call bullet from pool and subscribe on action(something like OnEnemyHit)
        }

        public override void Stop()
        {
            Debug.Log("Stop shoot");
            _inputActions.Player.Touch.performed -= OnTouchHandler;
            //TODO: stop any animation
        }
    }
}