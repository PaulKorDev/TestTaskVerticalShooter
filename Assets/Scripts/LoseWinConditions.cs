using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts
{
    public class LoseWinConditions
    {
        private EventBus _eventBus;
        private EnemySpawner _enemySpawner;
        public LoseWinConditions()
        {
            _eventBus = ServiceLocator.Get<EventBus>();
            _enemySpawner = GameObject.FindAnyObjectByType<EnemySpawner>();

            _eventBus.OnEnemyReturned.Subscribe(CheckWinLoseConditions);
        }
        private void CheckWinLoseConditions()
        {
            if (CheckLoseCondition())
                return;
            CheckWinCondition();
        }
        private bool CheckLoseCondition()
        {
            int hp = ServiceLocator.Get<Player.Player>().GetHP();
            if (hp <= 0)
            {
                _eventBus.OnPlayerLost.Trigger();
            }
            return hp <= 0;
        }
        private void CheckWinCondition()
        {
            var leftEnemies = ServiceLocator.Get<EnemyObjectPool>().CountActiveObjects();
            var playerHP = ServiceLocator.Get<Player.Player>().GetHP();
            var allEnemiesAlreadySpawned = _enemySpawner.isAllUnitSpawned();
            Debug.Log($"lEFT: {leftEnemies}, HP: {playerHP}, spawned: {allEnemiesAlreadySpawned}");
            if (allEnemiesAlreadySpawned && playerHP != 0 && leftEnemies == 0)
            {
                _eventBus.OnPlayerWon.Trigger();
            }
        }
    }
}
