using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace State
{
    public class PlayerIdleState : BaseState
    {
        private readonly Player _player;
        private readonly float _timeBeforeInputOn;
        private readonly Transform _playerTransform;
        private readonly Transform _playerSpawnPosition;
        private readonly List<GameObject> _allEnemies;

        public PlayerIdleState(Player player, IStateSwitcher stateSwitcher, InputActions inputActions, Transform playerSpawnPosition, List<GameObject> allEnemies) : base(player, stateSwitcher, inputActions)
        {
            _player = player;
            _timeBeforeInputOn = player.GetTimeWaitBeforeInputOn;
            _playerTransform = player.GetPlayerTransform;
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
            _player.StartCoroutine(WaitBeforeInputOn());
        }

        private IEnumerator WaitBeforeInputOn()
        {
            yield return new WaitForSeconds(_timeBeforeInputOn);
            _inputActions.Player.Touch.performed += OnTouchHandler;
            _player.StopCoroutine(WaitBeforeInputOn());
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