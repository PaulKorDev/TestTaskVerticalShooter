using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Enemy.EnemyTypes
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class DefaultEnemy : EnemyBase
    {
        private Rigidbody2D _enemyRgb;
        private EnemyFactoryConfig _enemySettings;

        private void Awake()
        {
            _enemyRgb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Move();
        }
        override public void InitEnemy()
        {
            _enemySettings = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
            SetSpeed();
            SetHP();
        }
        public override void Move()
        {
            _enemyRgb.velocity = Vector2.down * _speedMovement * Time.fixedDeltaTime;
        }
        private void SetHP() => _hp = _enemySettings.EnemyHP;
        private void SetSpeed() => _speedMovement = Random.Range(_enemySettings.SpeedMin, _enemySettings.SpeedMax);

    }
}
