﻿using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Enemy.Factory;
using Assets.Scripts.Player;
using Assets.Scripts.Shooting.AttackModes;
using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        [SerializeField] private GameConfig _settings;
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private Transform _bulletsContainer;
        public void RegisterAllServices()
        {
            //here register services
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

        private void RegisterPlayerMovement()
        {
            var playerMovement = new PlayerMovement();
            ServiceLocator.Register(playerMovement);
        }
        
        private void RegisterAttackMode()
        {
            var attackMode = GameObject.FindAnyObjectByType<AutoShooting>();
            ServiceLocator.Register(attackMode);
        }
        private void RegisterPlayer()
        {
            var player = GameObject.FindAnyObjectByType<Player.Player>();
            ServiceLocator.Register(player);
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
