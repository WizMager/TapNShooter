using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;
using UnityEngine.InputSystem;

namespace State
{
    public class PlayerShootState : BaseState
    {
        private readonly Player _player;
        private readonly float _timeWaitAfterShoot;
        private readonly Camera _camera;
        private readonly Transform _shootPosition;
        private readonly BulletPool _bulletPool;
        private readonly int _waypointsCount;
        private readonly int[] _enemySpawnPositions;
        private int _enemyCount;
        private int _checkedWaypoint;
        private readonly List<Bullet> _shootBullets = new List<Bullet>();

        public PlayerShootState(Player player, IStateSwitcher stateSwitcher, InputActions inputActions, GameObject bulletPrefab, int waypointsCount, int[] enemySpawnPosition) : base(player, stateSwitcher, inputActions)
        {
            _player = player;
            _timeWaitAfterShoot = player.GetTimeWaitAfterShoot;
            _camera = player.GetPlayerCamera;
            _shootPosition = player.GetShootPosition;
            _waypointsCount = waypointsCount - 1;
            _bulletPool = new BulletPool(bulletPrefab, 5);
            _enemySpawnPositions = enemySpawnPosition;
        }
        
        public override void Start()
        {
            _inputActions.Player.Touch.performed += OnTouchHandler;
            _enemyCount = _enemySpawnPositions[_checkedWaypoint];
        }

        private void OnTouchHandler(InputAction.CallbackContext obj)
        {
            //Debug.Log("On shoot Touch");
            _animator.CrossFade("Punch", 0.05f);
            var tapPosition = _inputActions.Player.TouchPosition.ReadValue<Vector2>();
            var shootRay = _camera.ScreenPointToRay(tapPosition);
            var bulletDirection = shootRay.GetPoint(20f) - _shootPosition.position;
            var bullet = _bulletPool.Pop();
            _shootBullets.Add(bullet);
            bullet.OnHit += OnHitHandler;
            bullet.Shoot(_shootPosition, bulletDirection.normalized);
        }

        private void OnHitHandler(Bullet bullet, bool killEnemy)
        {
            bullet.OnHit -= OnHitHandler;
            _bulletPool.Push(bullet);
            _shootBullets.Remove(bullet);
            if (!killEnemy) return;
            _enemyCount--;
            if (_enemyCount > 0) return;
            _inputActions.Player.Touch.performed -= OnTouchHandler;
            foreach (var shootBullet in _shootBullets)
            {
                shootBullet.OnHit -= OnHitHandler;
                _bulletPool.Push(shootBullet);
            }
            _shootBullets.Clear();
            _checkedWaypoint++;
            _player.StartCoroutine(WaitBeforeSwitchState());
        }

        private IEnumerator WaitBeforeSwitchState()
        {
            yield return new WaitForSeconds(_timeWaitAfterShoot);
            if (_checkedWaypoint == _waypointsCount)
            {
                _checkedWaypoint = 0;
                _stateSwitcher.SwitchState<PlayerIdleState>();
            }
            else
            {
                _stateSwitcher.SwitchState<PlayerRunState>(); 
            }
        }
        
        public override void Stop()
        {
            _player.StopCoroutine(WaitBeforeSwitchState());
        }
    }
}