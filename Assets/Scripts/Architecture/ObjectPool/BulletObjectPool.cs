using UnityEngine;
using Assets.Scripts.Enemy.Factory;
using Assets.Scripts.Shooting;
using Assets.Scripts.Architecture.ServiceLocator;

namespace Assets.Scripts.Architecture.ObjectPool
{
    public class BulletObjectPool : ObjectPool<Bullet>, IService
    {
        private static int _preload = 10;
        private static bool _autoExpand = true;
        private static Vector3 _targetPosition;

        public BulletObjectPool() : base(FactoryMethod, GetEffect, ReturnEffect, _preload, _autoExpand) 
        {
            EventBus.EventBus eventBus = ServiceLocator.ServiceLocator.Get<EventBus.EventBus>();
            eventBus.OnBulletMissed.Subscribe(ReturnObject);
            eventBus.OnBulletHit.Subscribe(ReturnObject);
            eventBus.GameRestarted.Subscribe(ReturnAllActiveObjects);
        }
        public Bullet GetObject(Vector3 spawnPoint, Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            return GetObject(spawnPoint);
        }

        private static Bullet FactoryMethod()
        {
            return ServiceLocator.ServiceLocator.Get<BulletFactory>().CreateBullet();
        }
        private static void GetEffect(Bullet bullet, Vector3 spawnPoint) {
            bullet.transform.position = spawnPoint;
            bullet.RotateToTargetAndSetDamage(_targetPosition);
            bullet.gameObject.SetActive(true);
        } 
        private static void ReturnEffect(Bullet bullet) => bullet.gameObject.SetActive(false);

    }
}
