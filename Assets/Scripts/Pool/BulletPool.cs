using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Pool
{
    public class BulletPool
    {
        private readonly GameObject _bulletPrefab;
        private readonly Stack<BulletView> _storage;
        private readonly Transform _rooTransform;

        public BulletPool(GameObject bulletPrefab, int storageAmount)
        {
            _bulletPrefab = bulletPrefab;
            _storage = new Stack<BulletView>(storageAmount);
            _rooTransform = new GameObject("PoolRoot").GetComponent<Transform>();
            FillPool(storageAmount);
        }

        public void Push(BulletView bulletView)
        {
            bulletView.gameObject.SetActive(false);
            _storage.Push(bulletView);
        }

        public BulletView Pop()
        {
            BulletView bulletView;
            if (_storage.Count > 0)
            {
                bulletView = _storage.Pop();
                bulletView.gameObject.SetActive(true);
            }
            else
            {
                bulletView = Create();
            }

            return bulletView;
        }

        private BulletView Create()
        {
            var bullet = Object.Instantiate(_bulletPrefab, _rooTransform);
            var bulletView = bullet.GetComponent<BulletView>();
            return bulletView;
        }

        private void FillPool(int storageAmount)
        {
            for (int i = 0; i < storageAmount; i++)
            {
                var bulletView = Create();
                bulletView.gameObject.SetActive(false);
                Push(bulletView); 
            }
        }
    }
}