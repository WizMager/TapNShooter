using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Action<Bullet, bool> OnHit;
    [SerializeField] private Rigidbody bulletRigidbody;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeBeforeReturnToPool;
    
    private void OnEnable()
    {
        StartCoroutine(DelayReturnToPool());
    }

    private IEnumerator DelayReturnToPool()
    {
        yield return new WaitForSeconds(timeBeforeReturnToPool);
        OnHit?.Invoke(this, false);
    }
    
    public void Shoot(Transform shootPosition, Vector3 forceDirection)
    {
        transform.SetPositionAndRotation(shootPosition.position, shootPosition.rotation);
        bulletRigidbody.AddForce(forceDirection * bulletSpeed * bulletRigidbody.mass, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyDead = other.GetComponent<Enemy>().TakeDamage();
            OnHit?.Invoke(this, enemyDead);
        }
        else
        {
            OnHit?.Invoke(this, false);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(DelayReturnToPool());
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularVelocity = Vector3.zero;
    }
}