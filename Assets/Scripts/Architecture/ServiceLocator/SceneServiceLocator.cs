using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Enemy.Factory;
using Assets.Scripts.Player;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        [SerializeField] private GameConfig _settings;
        [SerializeField] private Transform _enemyContainer;
        public void RegisterAllServices()
        {
            //here register services
            RegisterSettings();
            RegisterEventBus();
            RegisterEnemyFactory();
            RegisterEnemyObjectPool();
            RegisterPlayerMovement();

        }

        private void RegisterPlayerMovement()
        {
            var playerMovement = new PlayerMovement();
            ServiceLocator.Register(playerMovement);
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
            EnemyFactory factory = new DefaultEnemyFactory(_enemyContainer);
            ServiceLocator.Register(factory);
        }
        private void RegisterEnemyObjectPool()
        {
            EnemyObjectPool enemyPool = new EnemyObjectPool();
            ServiceLocator.Register(enemyPool);
        }
    }
}
