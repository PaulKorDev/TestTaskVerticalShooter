using UnityEngine;
using Assets.Scripts.Enemy.EnemyTypes;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.Factory;
using Assets.Scripts.Shooting;

namespace Assets.Scripts.Architecture.ObjectPool
{
    public class BulletObjectPool : ObjectPool<Bullet>, IService
    {
        private static int _preload = 10;
        private static bool _autoExpand = true;
        private static Vector3 _targetPosition;

        public BulletObjectPool() : base(FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand) { }

        private static Bullet FactoryMethod()
        {
            return ServiceLocator.ServiceLocator.Get<BulletFactory>().CreateBullet();
        }
        private static void GetEffect(Bullet bullet, Vector3 spawnPoint) {
            bullet.transform.position = spawnPoint;
            bullet.Init(_targetPosition);
            bullet.gameObject.SetActive(true);
        } 
        private static void ReturnEffect(Bullet bullet) => bullet.gameObject.SetActive(false);

        public Bullet GetObject(Vector3 spawnPoint, Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            return GetObject(spawnPoint);
        }
    }
}
