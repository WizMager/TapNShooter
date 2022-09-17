using UnityEngine;
using UnityEngine.InputSystem;

namespace State
{
    public class PlayerIdleState : BaseState
    {
        public PlayerIdleState(Animator animator, IStateSwitcher stateSwitcher, InputActions inputActions) : base(animator, stateSwitcher, inputActions)
        {
        }
        
        public override void Start()
        {
            _inputActions.Player.Touch.performed += OnTouchHandler;
            //TODO: start idle animation
        }

        private void OnTouchHandler(InputAction.CallbackContext obj)
        {
            _stateSwitcher.SwitchState<PlayerRunState>();
        }

        public override void Stop()
        {
            //TODO: stop idle animation
        }
    }
}