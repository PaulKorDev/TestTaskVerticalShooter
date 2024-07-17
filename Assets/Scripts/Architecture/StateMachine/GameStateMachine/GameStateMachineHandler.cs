﻿using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Architecture.StateMachine
{
    public class GameStateMachineHandler : MonoBehaviour 
    {
        private StateMachine<GameState> _concreteStateMachine = new StateMachine<GameState>();
        [SerializeField] private SceneServiceLocator _sceneServiceLocator;
        [SerializeField] private EnemySpawner _enemySpawner;

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
            _concreteStateMachine.AddState(new BootstrapState(_concreteStateMachine, _sceneServiceLocator, _enemySpawner));
            _concreteStateMachine.AddState(new RestartState(_concreteStateMachine));
            _concreteStateMachine.AddState(new GameplayLoopState(_concreteStateMachine));
        }
    }
}
