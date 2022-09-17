
namespace State
{
    public class PlayerState : IStateSwitcher
    {
        private BaseState _currentState;

        public void Initialize(BaseState state)
        {
            _currentState = state;
            _currentState.Start();
        }

        public void ChangeState(BaseState newState)
        {
            _currentState.Stop();
            _currentState = newState;
            _currentState.Start();
        }

        public void SwitchState<T>() where T : BaseState
        {
            
        }
    }
}