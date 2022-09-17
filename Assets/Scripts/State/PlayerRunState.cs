using UnityEngine;

namespace State
{
    public class PlayerRunState : BaseState
    {
        public PlayerRunState(Animator animator, IStateSwitcher stateSwitcher, InputActions inputActions) : base(animator, stateSwitcher, inputActions)
        {
        }

        public override void Start()
        {
            //TODO: start run animation
        }

        public override void Update()
        {
            //TODO: go to next waypoint with navmesh end switch to shoot state after path distance = 0
            //_stateSwitcher.SwitchState<PlayerShootState>();
        }

        public override void Stop()
        {
            //TODO: stop run animation
        }
    }
}