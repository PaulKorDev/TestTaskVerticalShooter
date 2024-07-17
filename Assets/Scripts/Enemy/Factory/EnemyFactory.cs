using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;

namespace Assets.Scripts.Enemy.Factory
{
    abstract public class EnemyFactory : IService
    {
        protected EnemyFactoryConfig _enemyFactoryConfig;
        protected EnemyFactory() {
            _enemyFactoryConfig = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
        }

        public abstract EnemyBase CreateEnemy();

    }
}
