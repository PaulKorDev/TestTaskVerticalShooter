using System;
using System.Collections.Generic;

namespace Assets.Scripts.Architecture.StateMachine
{
    public interface IState
    {
        public void Enter();
    }
    public class StateMachine <T> where T : IState
    {
        public T CurrentState;
        private readonly Dictionary<string, T> _states = new();

        public void AddState<T1>(T1 state) where T1 : T
        {
            string key = typeof(T1).Name;

            if (_states.ContainsKey(key))
            {
                throw new Exception($"AddStateError: StateMachine already contains {key}");
            }

            _states.Add(key, state);
        }
        public void EnterToState<T1>() where T1 : T
        {
            string key = typeof(T1).Name;

            if (!_states.ContainsKey(key))
            {
                throw new Exception($"EnterToStateError: {key} not added in StateMachine");
            }

            CurrentState = _states[key];
            CurrentState.Enter();
        }
    }
}
