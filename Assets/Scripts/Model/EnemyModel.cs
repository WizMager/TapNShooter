using Data;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Model
{
    public class EnemyModel
    {
        private readonly int _startHealth;
        private int _health;
        private float _deactivateTime;
        private Slider _healthSlider;
        private Animator _animator;
        private CapsuleCollider _hitCollider;
        private Rigidbody[] _rigidbodies;
        private Transform _hip;
        private Transform _cameraTransform;
        private readonly Vector3 _startHipsPosition;

        public EnemyModel(EnemyView enemy, Transform camera)
        {
            _startHealth = enemy.GetStartHealth;
            _deactivateTime = enemy.GetDeactivateTime;
            _healthSlider = enemy.GetSlider;
            _animator = enemy.GetAnimator;
            _hitCollider = enemy.GetHitCollider;
            _rigidbodies = enemy.GetRagDollRigidbodies;
            _hip = enemy.GetHip;
            _cameraTransform = camera;
            _health = _startHealth;
            _startHipsPosition = _hip.position;
        }
        
        
    }
}