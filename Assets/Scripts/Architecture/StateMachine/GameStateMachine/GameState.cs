namespace Assets.Scripts.Architecture.StateMachine
{
    public abstract class   GameState : IState, ILogicState
    {
        protected StateMachine<GameState> _stateMachine;
        public GameState(StateMachine<GameState> stateMachine) {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void UpdateLogic();
    }
}
