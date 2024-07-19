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
        private EventBus _eventBus;

        public void TimeOutSpawn()
        {
            if (_timeOut <= 0 && !isAllUnitSpawned())
            {
                SpawnNewUnit();
                UpdateTimer();
            }
            _timeOut -= Time.deltaTime;
        }

        public void Init()
        {
            _eventBus = ServiceLocator.Get<EventBus>();
            _enemySpawnConfig = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;

            SubscribeToSignals();
            UpdateSpawnCount();
        }
        public bool isAllUnitSpawned()
        {
            return _alreadySpawned >= _spawnCount;
        }

        private void UpdateSpawnCount() {
            _alreadySpawned = 0;
            _spawnCount = Random.Range(_enemySpawnConfig.EnemyCountMin, _enemySpawnConfig.EnemyCountMax);
        }
        private void SubscribeToSignals()
        {
            _eventBus.OnEnemyDied.Subscribe(RemoveEnemy, 4);
            _eventBus.OnFinishLineReached.Subscribe(RemoveEnemy, 3);
            _eventBus.GameRestarted.Subscribe(RemoveAllEnemies);
            _eventBus.GameRestarted.Subscribe(UpdateSpawnCount);

        }
        private void SpawnNewUnit()
        {
            int randomIndex = Random.Range(0, _spawnPoints.Length);
            ServiceLocator.Get<EnemyObjectPool>().GetObject(_spawnPoints[randomIndex].position);
            _alreadySpawned++;
        }
        private void UpdateTimer() => _timeOut = Random.Range(_enemySpawnConfig.TimeoutMin, _enemySpawnConfig.TimeoutMin);

        private void RemoveAllEnemies()
        {
            ServiceLocator.Get<EnemyObjectPool>().ReturnAllActiveObjects();
        }
        private void RemoveEnemy(EnemyBase enemy)
        {
            ServiceLocator.Get<EnemyObjectPool>().ReturnObject(enemy);
            _eventBus.OnEnemyReturned.Trigger();
        }
        
    }
}
