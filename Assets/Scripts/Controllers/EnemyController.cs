using System.Collections.Generic;
using Controllers.Interfaces;
using Model;
using UnityEngine;
using Views;

namespace Controllers
{
    public class EnemyController : IEnable, IFixedUpdate, IDisable
    {
        private List<EnemyModel> _enemyModels = new List<EnemyModel>();
        
        public EnemyController(EnemyView[] enemies, Transform camera)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].EnemyNumber = i;
                _enemyModels.Add(new EnemyModel(enemies[i], camera));
            }
        }
        
        public void OnEnable()
        {
            RigidbodyActivation(false);
            // hips.position = _startHipsPosition;
            // rootCollider.enabled = true;
            // healthSlider.gameObject.SetActive(true);
            // _health = startHealth;
            // healthSlider.maxValue = startHealth;
            // healthSlider.value = _health;
            // animator.enabled = true;
        }

        public void FixedUpdate()
        {
            //healthSlider.transform.LookAt(_cameraTransform);  
        }

        public void OnDisable()
        {
            //StopCoroutine(DeactivationEnemy());  
        }
        
        private void TakeDamage()
        {
            // _health--;
            // healthSlider.value = _health;
            // if (_health > 0) return false;
            // animator.enabled = false;
            // StartCoroutine(DeactivationEnemy());
        }

        // private IEnumerator DeactivationEnemy()
        // {
        //     healthSlider.gameObject.SetActive(false);
        //     rootCollider.enabled = false;
        //     RigidbodyActivation(true);
        //     yield return new WaitForSeconds(deactivateTime);
        //     gameObject.SetActive(false);
        // }

        private void RigidbodyActivation(bool activate)
        {
            // foreach (var rb in rigidbodies)
            // {
            //     rb.isKinematic = !activate;
            // }
        }
    }
}