using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Configs;
using Assets.Scripts.Enemy.Factory;
using Assets.Scripts.Player;
using Assets.Scripts.Shooting.AttackModes;
using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        [SerializeField] private GameConfig _settings;
        [SerializeField] private AutoShooting _autoShooting;
        [SerializeField] private Player.Player _player;
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private Transform _bulletsContainer;
        public void RegisterAllServices()
        {
            //here register services
            RegisterScreenLimits();
            RegisterSettings();
            RegisterEventBus();
            RegisterEnemyFactory();
            RegisterEnemyObjectPool();
            RegisterBulletFactory();
            RegisterBulletObjectPool();
            RegisterAttackMode();
            RegisterPlayer();
            RegisterPlayerMovement();

        }
        private void RegisterScreenLimits()
        {
            var screenLimits = new ScreenLimits();
            ServiceLocator.Register(screenLimits);
        }
        private void RegisterPlayerMovement()
        {
            var playerMovement = new PlayerMovement(new PlayerMovementLimits());
            ServiceLocator.Register(playerMovement);
        }

        private void RegisterAttackMode()
        {
            _autoShooting.Init();
            ServiceLocator.Register(_autoShooting);
        }
        private void RegisterPlayer()
        {
            ServiceLocator.Register(_player);
        }
        private void RegisterEventBus()
        {
            EventBus.EventBus eventBus = new();
            ServiceLocator.Register(eventBus);
        }
        private void RegisterSettings()
        {
            ServiceLocator.Register(_settings);
        }
        private void RegisterEnemyFactory() {
            EnemyFactory factory = new DefaultEnemyFactory(_enemiesContainer);
            ServiceLocator.Register(factory);
        }
        private void RegisterBulletFactory()
        {
            BulletFactory factory = new BulletFactory(_bulletsContainer);
            ServiceLocator.Register(factory);
        }
        private void RegisterEnemyObjectPool()
        {
            EnemyObjectPool enemyPool = new EnemyObjectPool();
            ServiceLocator.Register(enemyPool);
        }
        private void RegisterBulletObjectPool()
        {
            BulletObjectPool bulletPool = new BulletObjectPool();
            ServiceLocator.Register(bulletPool);
        }
    }
}
