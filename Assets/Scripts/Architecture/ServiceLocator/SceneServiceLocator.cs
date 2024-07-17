using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.Factory;
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
            RegisterEnemyFactory();
            RegisterEnemyObjectPool();

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
