namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class GameplayLoadState : GameState
    {
        public GameplayLoadState(StateMachine<GameState> stateMachine) : base(stateMachine) {

        }

        public override void Enter()
        {
            _stateMachine.EnterToState<GameplayLoopState>();
        }

        public override void UpdateLogic()
        {
           
        }

    }
}
