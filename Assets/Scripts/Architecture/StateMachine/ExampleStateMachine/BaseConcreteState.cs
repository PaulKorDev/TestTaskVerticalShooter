namespace Assets.Scripts.Architecture.StateMachine
{
    public abstract class BaseConcreteState : IState, ILogicState
    {
        protected StateMachine<BaseConcreteState> _stateMachine;
        public BaseConcreteState(StateMachine<BaseConcreteState> stateMachine) {
            _stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void UpdateLogic();
    }
}
