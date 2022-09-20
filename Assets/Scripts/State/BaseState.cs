using UnityEngine;

namespace State
{
    public abstract class BaseState
    {
        protected Animator _animator;
        protected IStateSwitcher _stateSwitcher;
        protected InputActions _inputActions;

        protected BaseState(Player player, IStateSwitcher stateSwitcher, InputActions inputActions)
        {
            _animator = player.GetAnimator;
            _stateSwitcher = stateSwitcher;
            _inputActions = inputActions;
        }

        public abstract void Start();
        
        public abstract void Stop();

        public virtual void Update()
        {
            
        }
    }
}