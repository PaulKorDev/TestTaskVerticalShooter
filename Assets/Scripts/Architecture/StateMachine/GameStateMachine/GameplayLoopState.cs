using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class GameplayLoopState : GameState
    {
        public GameplayLoopState(StateMachine<GameState> stateMachine) : base(stateMachine) {

        }

        public override void Enter()
        {
            //ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnPlayerLost.Subscribe(PauseGame);
            ServiceLocator.ServiceLocator.Get<EventBus.EventBus>().OnButtonRestartClicked.Subscribe(RestartGame);
            ContinueGame();
        }

        public override void UpdateLogic()
        {
           //PlayerMovement
           //EnemyMovement
           //BulletMovement
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }
        private void ContinueGame()
        {
            Time.timeScale = 1;
        }
        private void RestartGame()
        {
            _stateMachine.EnterToState<RestartState>();
        }

    }
}
