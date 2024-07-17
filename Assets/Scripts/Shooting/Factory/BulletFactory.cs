using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Configs;
using Assets.Scripts.Shooting;
using UnityEngine;

namespace Assets.Scripts.Enemy.Factory
{
    public class BulletFactory : IService
    {
        private Bullet _prefab;
        private Transform _bulletContainer;
        public BulletFactory(Transform bulletContainer) {
            _prefab = Resources.Load<Bullet>(PrefabsPaths.BULLET);
            _bulletContainer = bulletContainer;
        }

        public Bullet CreateBullet()
        {
            Bullet bullet = GameObject.Instantiate(_prefab, _bulletContainer);
            bullet.Init();
            return bullet;
        }

    }
}
