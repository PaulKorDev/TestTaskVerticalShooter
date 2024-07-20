using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Configs;
using Assets.Scripts.Enemy;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class BootstrapState : GameState
    {
        private SceneServiceLocator _serviceLocator;
        private EnemySpawner _enemySpawner;
        private ScreenScaler _screenScaler;
        public BootstrapState(StateMachine<GameState> stateMachine, SceneServiceLocator serviceLocator, EnemySpawner enemySpawner, ScreenScaler screenScaler) : base(stateMachine) 
        {
            _serviceLocator = serviceLocator;
            _enemySpawner = enemySpawner;
            _screenScaler = screenScaler;
        }

        public override void Enter()
        {
            _serviceLocator.RegisterAllServices();

            InitAll();

            _stateMachine.EnterToState<RestartState>();
        }

        public override void UpdateLogic() { }
        public override void UpdatePhysic() { }

        private void InitAll()
        {
            _enemySpawner.Init();
            LoseWinConditions loseWinConditions = new LoseWinConditions();
            _screenScaler.Init();

        }
    }
}
