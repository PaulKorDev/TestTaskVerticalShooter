using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;

        private float _timeOut;
        private int _spawnCount;
        private int _alreadySpawned;
        private EnemyFactoryConfig _enemySpawnConfig;

        private void Update()
        {
            if (_timeOut <= 0 && _alreadySpawned < _spawnCount)
            {
                int randomIndex = Random.Range(0, _spawnPoints.Length);
                ServiceLocator.Get<EnemyObjectPool>().GetObject(_spawnPoints[randomIndex].position);
                _alreadySpawned++;
                UpdateTimer();
            }
            _timeOut -= Time.deltaTime;
        }

        public void Init()
        {
            ServiceLocator.Get<EventBus>().OnEnemyDied.Subscribe(RemoveEnemy);
            ServiceLocator.Get<EventBus>().OnFinishLineReached.Subscribe(RemoveEnemy);

            _enemySpawnConfig = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
            UpdateSettings();
        }

        public void UpdateSettings()
        {
            UpdateSpawnCount();
        }

        private void UpdateSpawnCount() {
            _alreadySpawned = 0;
            _spawnCount = Random.Range(_enemySpawnConfig.EnemyCountMin, _enemySpawnConfig.EnemyCountMax);
        }
        private void UpdateTimer() => _timeOut = Random.Range(_enemySpawnConfig.TimeoutMin, _enemySpawnConfig.TimeoutMin);

        private void RemoveEnemy(EnemyBase enemy) => ServiceLocator.Get<EnemyObjectPool>().ReturnObject(enemy);
    }
}
