using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class BootstrapState : GameState
    {
        private SceneServiceLocator _serviceLocator;
        private EnemySpawner _enemySpawner;
        public BootstrapState(StateMachine<GameState> stateMachine, SceneServiceLocator serviceLocator, EnemySpawner enemySpawner) : base(stateMachine) 
        {
            _serviceLocator = serviceLocator;
            _enemySpawner = enemySpawner;
        }

        public override void Enter()
        {
            _serviceLocator.RegisterAllServices();

            _enemySpawner.Init();

            _stateMachine.EnterToState<RestartState>();
        }

        public override void UpdateLogic()
        {

        }
    }
}
