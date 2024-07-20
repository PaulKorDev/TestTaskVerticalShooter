using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using Assets.Scripts.Shooting;
using UnityEngine;

namespace Assets.Scripts.Architecture.EventBus
{
    public class EventBus : IService
    {
        public CustomEvent<EnemyBase> OnEnemyDied { get; private set; }  = new();
        public CustomEvent<EnemyBase> OnFinishLineReached { get; private set; }  = new();
        public CustomEvent<Bullet> OnBulletMissed { get; private set; }  = new();
        public CustomEvent<Bullet> OnBulletHit { get; private set; }  = new();
        public CustomEvent<Vector3> OnEnemyFound { get; private set; }  = new();
        public CustomEvent<Vector3> OnReadyToShoot { get; private set; }  = new();
        public CustomEvent<int> OnHealthChanged { get; private set; }  = new();
        public CustomEvent OnEnemyReturned { get; private set; } = new();
        public CustomEvent OnPlayerWon { get; private set; }  = new();
        public CustomEvent OnPlayerLost { get; private set; }  = new();
        public CustomEvent GameRestarted { get; private set; }  = new();
        public CustomEvent OnButtonRestartClicked { get; private set; }  = new();
    }
}
