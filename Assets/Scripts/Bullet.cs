﻿using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Action<Bullet, bool> OnHit;
    [SerializeField] private Rigidbody bulletRigidbody;
    [SerializeField] private float bulletSpeed;

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
        bulletRigidbody.velocity = Vector3.zero;
        bulletRigidbody.angularVelocity = Vector3.zero;
    }
}