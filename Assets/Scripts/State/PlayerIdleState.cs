using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Views;

namespace State
{
    public class PlayerIdleState : BaseState
    {
        private readonly Transform _playerTransform;
        private readonly Transform _playerSpawnPosition;
        private readonly List<GameObject> _allEnemies;

        public PlayerIdleState(PlayerView playerView, IStateSwitcher stateSwitcher, InputActions inputActions, Transform playerSpawnPosition, List<GameObject> allEnemies) : base(playerView, stateSwitcher, inputActions)
        {
            _playerTransform = playerView.GetPlayerTransform;
            _playerSpawnPosition = playerSpawnPosition;
            _allEnemies = allEnemies;
        }
        
        public override void Start()
        {
            _playerTransform.SetPositionAndRotation(_playerSpawnPosition.position, _playerSpawnPosition.rotation);
            foreach (var enemy in _allEnemies)
            {
                enemy.SetActive(false);
                enemy.SetActive(true);
            }
            _inputActions.Player.Touch.performed += OnTouchHandler;
        }

        private void OnTouchHandler(InputAction.CallbackContext obj)
        {
            _stateSwitcher.SwitchState<PlayerRunState>();
        }

        public override void Stop()
        {
            _inputActions.Player.Touch.performed -= OnTouchHandler;
        }
    }
}