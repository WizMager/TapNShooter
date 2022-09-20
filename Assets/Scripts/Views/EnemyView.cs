using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Animator animator;
        [SerializeField] private CapsuleCollider hitCollider;
        [SerializeField] private Rigidbody[] rigidbodies;
        [SerializeField] private Transform hip;
        [SerializeField] private int startHealth;
        [SerializeField] private float deactivateTime;
        private int _number;

        public Slider GetSlider => healthSlider;
        public Animator GetAnimator => animator;
        public CapsuleCollider GetHitCollider => hitCollider;
        public Rigidbody[] GetRagDollRigidbodies => rigidbodies;
        public Transform GetHip => hip;
        public int GetStartHealth => startHealth;
        public float GetDeactivateTime => deactivateTime;
        public int EnemyNumber { get; set; }
        
        
        private void OnEnable()
        {
            
        }

        private void FixedUpdate()
        {
            
        }

        private void OnDisable()
        {
            
        }

        
    }
}