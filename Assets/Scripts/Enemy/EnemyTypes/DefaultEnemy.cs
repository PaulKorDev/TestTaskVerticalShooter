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

        override public void InitEnemy()
        {
            _enemySettings = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
            SetSpeed();
            SetHP();
        }
        public override void Move()
        {
            transform.Translate(Vector3.down * _speedMovement * Time.deltaTime);
            //_enemyRgb.velocity = Vector2.down.normalized * _speedMovement * Time.fixedDeltaTime;
        }
        private void SetHP() => _hp = _enemySettings.EnemyHP;
        private void SetSpeed() => _speedMovement = Random.Range(_enemySettings.SpeedMin, _enemySettings.SpeedMax);

    }
}
