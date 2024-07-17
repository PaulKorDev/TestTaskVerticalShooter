using Assets.Scripts.Architecture.ServiceLocator;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class BootstrapState : GameState
    {
        private SceneServiceLocator _serviceLocator;
        public BootstrapState(StateMachine<GameState> stateMachine, SceneServiceLocator serviceLocator) : base(stateMachine) 
        {
            _serviceLocator = serviceLocator;
        }

        public override void Enter()
        {
            _serviceLocator.RegisterAllServices();

            _stateMachine.EnterToState<GameplayLoopState>();
        }

        public override void UpdateLogic()
        {

        }
    }
}
