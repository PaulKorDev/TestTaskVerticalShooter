using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;

namespace Assets.Scripts.Architecture.EventBus
{
    public class EventBus : IService
    {
        public CustomEvent<EnemyBase> OnEnemyDied = new();
        public CustomEvent<EnemyBase> OnFinishLineReached = new();
        public CustomEvent OnPlayerWon = new();
        public CustomEvent OnPlayerLost = new();
    }
}
