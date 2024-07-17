using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;

        private int _spawnCount;
        private float _timeOut;

        private EnemyFactoryConfig _enemySpawnConfig;

        private void Update()
        {
            _timeOut -= Time.deltaTime;
            if (_timeOut <= 0)
            {
                //objectPool.Get();
                UpdateTimer();
            }
        }

        public void Init()
        {
            //AddListener.EnemyKilled += RemoveEnemy

            _enemySpawnConfig = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
            UpdateSettings();
        }

        public void UpdateSettings()
        {
            UpdateSpawnCount();
            UpdateTimer();
        }

        private void UpdateSpawnCount() => _spawnCount = Random.Range(_enemySpawnConfig.EnemyCountMin, _enemySpawnConfig.EnemyCountMax);
        private void UpdateTimer() => _timeOut = Random.Range(_enemySpawnConfig.TimeoutMin, _enemySpawnConfig.TimeoutMin);

        private void RemoveEnemy(EnemyBase enemy)
        {
            //objectPool.Return(enemy)
        }


    }
}
