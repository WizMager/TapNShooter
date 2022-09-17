using UnityEngine;

namespace State
{
    public abstract class BaseState
    {
        protected Animator _animator;
        protected IStateSwitcher _stateSwitcher;
        protected InputActions _inputActions;

        protected BaseState(Animator animator, IStateSwitcher stateSwitcher, InputActions inputActions)
        {
            _animator = animator;
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