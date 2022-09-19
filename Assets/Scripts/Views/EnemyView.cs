using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private int startHealth;
        [SerializeField] private Slider healthSlider;
        private int _health;
        private Transform _cameraTransform;

        public void SetCameraTransform(Transform cameraTransform)
        {
            _cameraTransform = cameraTransform;
        }
        
        private void OnEnable()
        {
            _health = startHealth;
            healthSlider.maxValue = startHealth;
            healthSlider.value = _health;
        }

        public bool TakeDamage()
        {
            _health--;
            healthSlider.value = _health;
            if (_health > 0) return false;
            gameObject.SetActive(false); 
            return true;
        }

        private void FixedUpdate()
        {
            healthSlider.transform.LookAt(_cameraTransform);
        }
    }
}