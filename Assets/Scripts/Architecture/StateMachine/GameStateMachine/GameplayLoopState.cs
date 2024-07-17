namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class GameplayLoopState : GameState
    {
        public GameplayLoopState(StateMachine<GameState> stateMachine) : base(stateMachine) {

        }

        public override void Enter()
        {
        }

        public override void UpdateLogic()
        {
           //
        }

    }
}
