using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using Assets.Scripts.Shooting;

namespace Assets.Scripts.Architecture.EventBus
{
    public class EventBus : IService
    {
        public CustomEvent<EnemyBase> OnEnemyDied = new();
        public CustomEvent<EnemyBase> OnFinishLineReached = new();
        public CustomEvent<Bullet> OnBulletMissed = new();
        public CustomEvent<Bullet> OnBulletHit = new();
        public CustomEvent<int> OnHealthChanged = new();
        public CustomEvent OnPlayerWon = new();
        public CustomEvent OnPlayerLost = new();
        public CustomEvent GameRestarted = new();
        public CustomEvent OnButtonRestartClicked = new();
    }
}
