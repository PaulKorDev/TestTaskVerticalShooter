namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class BootstrapState : GameState
    {
        public BootstrapState(StateMachine<GameState> stateMachine) : base(stateMachine) {}

        public override void Enter()
        {
            _stateMachine.EnterToState<GameplayLoadState>();

        }

        public override void UpdateLogic()
        {

        }
    }
}
