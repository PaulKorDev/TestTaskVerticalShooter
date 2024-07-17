using Assets.Scripts.Configs;
using Assets.Scripts.Enemy.EnemyTypes;
using UnityEngine;

namespace Assets.Scripts.Enemy.Factory
{
    public class DefaultEnemyFactory : EnemyFactory
    {
        private DefaultEnemy _prefab;
        private Transform _enemyContainer;
        public DefaultEnemyFactory(Transform enemyContainer) : base() 
        {
            _prefab = Resources.Load<DefaultEnemy>(PrefabsPaths.DEFAULT_ENEMY);
            _enemyContainer = enemyContainer;
        }
        public override EnemyBase CreateEnemy()
        {
            DefaultEnemy defaultEnemy = GameObject.Instantiate(_prefab, _enemyContainer);
            return defaultEnemy;
        }
    }
}
