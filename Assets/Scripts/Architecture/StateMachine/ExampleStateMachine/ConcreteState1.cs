using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Architecture.StateMachine
{
    public sealed class ConcreteState1 : BaseConcreteState
    {
        private float timer;
        private Text _text;

        public ConcreteState1(StateMachine<BaseConcreteState> stateMachine, Text text) : base(stateMachine) {
            _text = text;
        }

        public override void Enter()
        {
            timer = 5f;
        }

        public override void UpdateLogic()
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
                _text.text = $"Current state: 1\n{Math.Round(timer, 2)} seconds remain";
            }
            else
            {
                _stateMachine.EnterToState<ConcreteState2>();
            }
        }
    }
}
