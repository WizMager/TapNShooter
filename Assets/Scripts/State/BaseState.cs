using UnityEngine;
using Views;

namespace State
{
    public abstract class BaseState
    {
        protected Animator _animator;
        protected IStateSwitcher _stateSwitcher;
        protected InputActions _inputActions;

        protected BaseState(PlayerView playerView, IStateSwitcher stateSwitcher, InputActions inputActions)
        {
            _animator = playerView.GetAnimator;
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