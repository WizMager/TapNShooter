using Pool;
using UnityEngine;
using UnityEngine.InputSystem;
using Views;

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
        
        public PlayerShootState(PlayerView playerView, IStateSwitcher stateSwitcher, InputActions inputActions, GameObject bulletPrefab, int waypointsCount) : base(playerView, stateSwitcher, inputActions)
        {
            _camera = playerView.GetPlayerCamera;
            _shootPosition = playerView.GetShootPosition;
            _waypointsCount = waypointsCount;
            _bulletPool = new BulletPool(bulletPrefab, 5);
        }
        
        public override void Start()
        {
            Debug.Log("Start shoot");
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
            //Debug.DrawRay(_shootPosition.position, bulletDirection.normalized, Color.red, 1000f);
        }

        private void OnHitHandler(BulletView bulletView, bool hitEnemy)
        {
            bulletView.OnHit -= OnHitHandler;
            _bulletPool.Push(bulletView);
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
            Debug.Log("Stop shoot");
            _inputActions.Player.Touch.performed -= OnTouchHandler;
        }
    }
}