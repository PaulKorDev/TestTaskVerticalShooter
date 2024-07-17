using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Enemy.EnemyTypes
{
    public abstract class EnemyBase : MonoBehaviour
    {
        private int _hp;
        protected float _speedMovement;

        private EnemyFactoryConfig _enemySettings;

        protected EnemyBase()
        {
            _enemySettings = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
        }
        abstract public void Move();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle") {
                //EventBus.OnFinishLineReached
            }
        }

        public void InitEnemy()
        {
            SetSpeed();
            SetHP();
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0) {
                throw new System.Exception("Damage can't be more than 0");
            }
            _hp = Mathf.Clamp(_hp - damage, 0, _hp);

            CheckIsDead();
        }
        private void CheckIsDead() {
            if (_hp == 0)
            {
                //EventBus.Trigger(OnEnemyKilled)
            }
        }

        private void SetHP() => _hp = _enemySettings.EnemyHP;
        private void SetSpeed() => _speedMovement = Random.Range(_enemySettings.SpeedMin, _enemySettings.SpeedMax);

    }
}
