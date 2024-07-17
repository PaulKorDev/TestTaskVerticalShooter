using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IService
    {
        [SerializeField] private int _maxHp;
        [SerializeField] private float _speedMovement;
        private int _hp;


        private PlayerMovement _movement;
        private EventBus _eventBus;

        private void Start()
        {
            _eventBus = ServiceLocator.Get<EventBus>();
            _eventBus.OnFinishLineReached.Subscribe(ReduceHP);
            _eventBus.GameRestarted.Subscribe(InitPlayer);
        }

        public void InitPlayer()
        {
            SetHP();
        }

        public Rigidbody2D GetRigidBody()
        {
            return gameObject.GetComponent<Rigidbody2D>();
        }
        public float GetSpeed()
        {
            return _speedMovement;
        }
        private void SetHP()
        {
            _hp = _maxHp;
            ServiceLocator.Get<EventBus>().OnHealthChanged.Trigger(_hp);
        }
        private void ReduceHP(EnemyBase enemy)
        {
            _hp = Mathf.Clamp(--_hp, 0, _maxHp);
            ServiceLocator.Get<EventBus>().OnHealthChanged.Trigger(_hp);
            if (_hp <= 0)
                _eventBus.OnPlayerLost.Trigger();
        }
    }
}
