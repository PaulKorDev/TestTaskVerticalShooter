using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Architecture.StateMachine
{
    public class ConcreteStateMachineManager : MonoBehaviour
    {
        private Text _mainText;
        private StateMachine<BaseConcreteState> _concreteStateMachine = new StateMachine<BaseConcreteState>();

        private void Awake()
        {
            _mainText = GetComponent<Text>();

            AddStates();
            _concreteStateMachine.EnterToState<ConcreteState1>();
        }

        private void Update()
        {
            _concreteStateMachine.CurrentState.UpdateLogic();
        }

        private void AddStates()
        {
            _concreteStateMachine.AddState(new ConcreteState1(_concreteStateMachine, _mainText));
            _concreteStateMachine.AddState(new ConcreteState2(_concreteStateMachine, _mainText));
        }
    }
}
