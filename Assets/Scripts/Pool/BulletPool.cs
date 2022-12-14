using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class BulletPool
    {
        private readonly GameObject _bulletPrefab;
        private readonly Stack<Bullet> _storage;
        private readonly Transform _rooTransform;

        public BulletPool(GameObject bulletPrefab, int storageAmount)
        {
            _bulletPrefab = bulletPrefab;
            _storage = new Stack<Bullet>(storageAmount);
            _rooTransform = new GameObject("PoolRoot").GetComponent<Transform>();
            FillPool(storageAmount);
        }

        public void Push(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _storage.Push(bullet);
        }

        public Bullet Pop()
        {
            Bullet bullet;
            if (_storage.Count > 0)
            {
                bullet = _storage.Pop();
                bullet.gameObject.SetActive(true);
            }
            else
            {
                bullet = Create();
            }

            return bullet;
        }

        private Bullet Create()
        {
            var bulletGameObject = Object.Instantiate(_bulletPrefab, _rooTransform);
            var bullet = bulletGameObject.GetComponent<Bullet>();
            return bullet;
        }

        private void FillPool(int storageAmount)
        {
            for (int i = 0; i < storageAmount; i++)
            {
                var bullet = Create();
                bullet.gameObject.SetActive(false);
                Push(bullet); 
            }
        }
    }
}