using System.Collections.Generic;
using System.Linq;
using Controllers.Interfaces;
using Data;
using Models;
using State;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : IEnable, IUpdate, IDisable, IStateSwitcher
    {
        private readonly InputActions _inputActions;
        private PlayerModel _playerModel;
        private Animator _playerAnimator;
        private BaseState _currentState;
        private readonly List<BaseState> _allStates;

        public PlayerController(PlayerData playerData)
        {
            _playerModel = new PlayerModel(playerData);
            _inputActions = new InputActions();
            _allStates = new List<BaseState>
            {
                new PlayerIdleState(_playerAnimator, this, _inputActions),
                new PlayerRunState(_playerAnimator, this, _inputActions),
                new PlayerShootState(_playerAnimator, this, _inputActions)
            };
            _currentState = _allStates[0];
        }

        public void OnEnable()
        {
            _inputActions.Player.Touch.Enable();
            _inputActions.Player.TouchPosition.Enable();
        }

        public void Update()
        {
            _currentState.Update();
        }
        
        public void OnDisable()
        {
            _inputActions.Player.Touch.Disable();
            _inputActions.Player.TouchPosition.Disable();
        }

        public void SwitchState<T>() where T : BaseState
        {
            var state = _allStates.FirstOrDefault(state => state is T);
            _currentState.Stop();
            state.Start();
            _currentState = state;
        }
    }
}