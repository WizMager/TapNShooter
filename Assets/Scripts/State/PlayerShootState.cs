using Pool;
using UnityEngine;
using UnityEngine.InputSystem;

namespace State
{
    public class PlayerShootState : BaseState
    {
        private readonly Camera _camera;
        private readonly Transform _shootPosition;
        private readonly BulletPool _bulletPool;
        private readonly int _waypointsCount;
        private int _enemyCount;
        private int _checkedWaypoint = 1;
        
        public PlayerShootState(Player player, IStateSwitcher stateSwitcher, InputActions inputActions, GameObject bulletPrefab, int waypointsCount) : base(player, stateSwitcher, inputActions)
        {
            _camera = player.GetPlayerCamera;
            _shootPosition = player.GetShootPosition;
            _waypointsCount = waypointsCount;
            _bulletPool = new BulletPool(bulletPrefab, 5);
        }
        
        public override void Start()
        {
            _inputActions.Player.Touch.performed += OnTouchHandler;
            _enemyCount = 4;
        }

        private void OnTouchHandler(InputAction.CallbackContext obj)
        {
            _animator.CrossFade("Punch", 0.05f);
            var tapPosition = _inputActions.Player.TouchPosition.ReadValue<Vector2>();
            var shootRay = _camera.ScreenPointToRay(tapPosition);
            var bulletDirection = shootRay.GetPoint(20f) - _shootPosition.position;
            var bulletView = _bulletPool.Pop();
            bulletView.OnHit += OnHitHandler;
            bulletView.Shoot(_shootPosition, bulletDirection.normalized);
        }

        private void OnHitHandler(Bullet bullet, bool hitEnemy)
        {
            bullet.OnHit -= OnHitHandler;
            _bulletPool.Push(bullet);
            if (!hitEnemy) return;
            _enemyCount--;
            if (_enemyCount > 0) return;
            _checkedWaypoint++;
            if (_checkedWaypoint == _waypointsCount)
            {
                _checkedWaypoint = 1;
                _stateSwitcher.SwitchState<PlayerIdleState>();
            }
            else
            {
                _stateSwitcher.SwitchState<PlayerRunState>(); 
            }
        }

        public override void Stop()
        {
            _inputActions.Player.Touch.performed -= OnTouchHandler;
        }
    }
}