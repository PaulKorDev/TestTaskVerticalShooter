using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class ConcreteState2 : BaseConcreteState
    {
        private Text _text;
        public ConcreteState2(StateMachine<BaseConcreteState> stateMachine, Text text) : base(stateMachine) {
            _text = text;
        }

        public override void Enter()
        {
            _text.text = "Current state: 2\nClick to enter to State 1";
        }

        public override void UpdateLogic()
        {
            if (Input.GetMouseButton(0))
                _stateMachine.EnterToState<ConcreteState1>();
        }
    }
}
