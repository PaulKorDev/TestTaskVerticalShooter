using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using Assets.Scripts.Shooting;
using Assets.Scripts.Shooting.AttackModes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class GameplayLoopState : GameState
    {
        private bool _isPaysed;
        private PlayerMovement _playerMovement;
        private EnemyObjectPool _enemyObjectPool;
        private BulletObjectPool _bulletObjectPool;
        private EnemySpawner _enemySpawner;
        private AutoShooting _attackMode;
        public GameplayLoopState(StateMachine<GameState> stateMachine) : base(stateMachine) {}

        public override void Enter()
        {
            _playerMovement = ServiceLocator.ServiceLocator.Get<PlayerMovement>();
            _enemyObjectPool = ServiceLocator.ServiceLocator.Get<EnemyObjectPool>();
            _bulletObjectPool = ServiceLocator.ServiceLocator.Get<BulletObjectPool>();
            if (_enemySpawner == null)
                _enemySpawner = GameObject.FindFirstObjectByType<EnemySpawner>();
            _attackMode = ServiceLocator.ServiceLocator.Get<AutoShooting>();

            SubscribeToSignals();
            ResumeGame();
        }
        public override void UpdateLogic() 
        {
            if (_isPaysed)
                return;

            PlayerInputHandler();
            PlayerMovement();
            EnemyMovement();
            SpawnEnemyLogic();
            SearchEnemyLogic();
            ShootLogic();
        }
        public override void UpdatePhysic()
        {
            if (_isPaysed)
                return ;

            BulletMovement();
        }

        private void SpawnEnemyLogic() => _enemySpawner.TimeOutSpawn();
        private void PlayerInputHandler() => _playerMovement.InputHandler();
        private void SearchEnemyLogic() => _attackMode.SearchEnemy();
        private void ShootLogic() => _attackMode.Shoot();
        private void PlayerMovement() => _playerMovement.Move();
        private void EnemyMovement()
        {
            foreach (var enemy in _enemyObjectPool.GetAllActiveObjects())
            {
                enemy.Move();
            };
        }
        private void BulletMovement()
        {
            var copyOfBulletsList = new List<Bullet>(_bulletObjectPool.GetAllActiveObjects());
            foreach (var bullet in copyOfBulletsList)
            {
                bullet.Fly();
            };
        }

        private void PauseGame() => _isPaysed = true; 
        private void ResumeGame() => _isPaysed = false;

        private void RestartGame()
        {
            UnsubscribeFromSignals();
            _stateMachine.EnterToState<RestartState>();
        }

        private void SubscribeToSignals()
        {
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnPlayerLost.Subscribe(PauseGame);
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnPlayerWon.Subscribe(PauseGame);
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnButtonRestartClicked.Subscribe(RestartGame);
        }
        private void UnsubscribeFromSignals()
        {
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnPlayerLost.Unsubscribe(PauseGame);
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnPlayerWon.Unsubscribe(PauseGame);
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnButtonRestartClicked.Unsubscribe(RestartGame);
        }

    }
}
