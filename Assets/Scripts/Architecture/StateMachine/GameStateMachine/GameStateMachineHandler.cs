using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public class GameStateMachineHandler : MonoBehaviour 
    {
        private StateMachine<GameState> _concreteStateMachine = new StateMachine<GameState>();
        [SerializeField] private SceneServiceLocator _sceneServiceLocator;

        private void Awake()
        {
            AddStates();
            _concreteStateMachine.EnterToState<BootstrapState>();
        }

        private void Update()
        {
            _concreteStateMachine.CurrentState.UpdateLogic();
        }

        private void AddStates()
        {
            _concreteStateMachine.AddState(new BootstrapState(_concreteStateMachine, _sceneServiceLocator));
            _concreteStateMachine.AddState(new GameplayLoopState(_concreteStateMachine));
        }
    }
}
