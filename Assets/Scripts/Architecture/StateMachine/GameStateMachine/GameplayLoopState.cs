using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using Assets.Scripts.Shooting.AttackModes;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class GameplayLoopState : GameState
    {
        private bool _isPaysed;
        private PlayerMovement _playerMovement;
        private EnemyObjectPool _enemyObjectPool;
        private EnemySpawner _enemySpawner;
        private AutoShooting _attackMode;
        public GameplayLoopState(StateMachine<GameState> stateMachine) : base(stateMachine) {}

        public override void Enter()
        {
            _playerMovement = ServiceLocator.ServiceLocator.Get<PlayerMovement>();
            _enemyObjectPool = ServiceLocator.ServiceLocator.Get<EnemyObjectPool>();
            _enemySpawner = GameObject.FindFirstObjectByType<EnemySpawner>();
            _attackMode = GameObject.FindFirstObjectByType<AutoShooting>();

            SubscribeToSignals();
            ResumeGame();
        }
        public override void UpdateLogic() 
        {
            if (!_isPaysed)
            {
                _playerMovement.InputHandler();
                _enemySpawner.TimeOutSpawn();
                EnemyMovement();
                _attackMode.SearchAndShoot();
            }
        }
        public override void UpdatePhysic()
        {
            if (!_isPaysed)
            {
                _playerMovement.Move();
                EnemyMovement();
                //BulletMovement
            }
        }
        private void EnemyMovement()
        {
            foreach (var enemy in _enemyObjectPool.GetAllActiveObjects())
            {
                enemy.Move();
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
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnButtonRestartClicked.Subscribe(RestartGame);
        }
        private void UnsubscribeFromSignals()
        {
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnPlayerLost.Unsubscribe(PauseGame);
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnButtonRestartClicked.Unsubscribe(RestartGame);
        }

    }
}
