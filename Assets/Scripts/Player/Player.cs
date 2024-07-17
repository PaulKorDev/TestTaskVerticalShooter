using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IService
    {
        [SerializeField] private int _hp;
        [SerializeField] private float _speedMovement;

        private PlayerMovement _movement;
        private EventBus _eventBus;

        private void Start()
        {
            var rgb = gameObject.GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(rgb);

            _eventBus = ServiceLocator.Get<EventBus>();
            _eventBus.OnFinishLineReached.Subscribe(ReduceHP);
            _eventBus.OnHealthChanged.Trigger(_hp); //For setting hp to PlayerGUI
        }

        public void FixedUpdate()
        {
            _movement.Move(_speedMovement);
        }

        private void ReduceHP(EnemyBase enemy)
        {
            _hp = Mathf.Clamp(--_hp, 0, _hp);
            ServiceLocator.Get<EventBus>().OnHealthChanged.Trigger(_hp);
            if (_hp <= 0)
                _eventBus.OnPlayerLost.Trigger();
        }
    }
}
