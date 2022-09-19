using System.Collections.Generic;
using System.Linq;
using Controllers.Interfaces;
using Data;
using State;
using UnityEngine;
using Views;

namespace Controllers
{
    public class PlayerController : IEnable, IUpdate, IDisable, IStateSwitcher
    {
        private readonly InputActions _inputActions;
        private BaseState _currentState;
        private readonly List<BaseState> _allStates;

        public PlayerController(PlayerView playerView, Transform[] waypoints, GameObject bulletPrefab, List<GameObject> allEnemies)
        {
            _inputActions = new InputActions();
            _allStates = new List<BaseState>
            {
                new PlayerIdleState(playerView, this, _inputActions, waypoints[0], allEnemies),
                new PlayerRunState(playerView, this, _inputActions, waypoints),
                new PlayerShootState(playerView, this, _inputActions, bulletPrefab, waypoints.Length)
            };
            _currentState = _allStates[0];
            _currentState.Start();
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