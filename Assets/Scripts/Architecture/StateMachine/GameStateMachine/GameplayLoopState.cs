using Assets.Scripts.Architecture.EntryPoint;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class GameplayLoopState : GameState
    {
        public GameplayLoopState(StateMachine<GameState> stateMachine) : base(stateMachine) {

        }

        public override void Enter()
        {
            ServiceLocator.ServiceLocator.Get<UIRoot>().HideLoadingScreen();
        }

        public override void UpdateLogic()
        {
           //
        }

    }
}
