using Assets.Scripts.Architecture.EventBus;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class RestartState : GameState
    {
        public RestartState(StateMachine<GameState> stateMachine) : base(stateMachine) {

        }

        public override void Enter()
        {
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().GameRestarted.Trigger();
            _stateMachine.EnterToState<GameplayLoopState>();
        }

        public override void UpdateLogic() { }

        public override void UpdatePhysic() { }
    }
}
