using UnityEngine;

namespace Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private int startHealth;
        private int _health;

        private void OnEnable()
        {
            _health = startHealth;
        }

        public bool TakeDamage()
        {
            _health--;
            if (_health > 0) return false;
            gameObject.SetActive(false); 
            return true;
        }
    }
}