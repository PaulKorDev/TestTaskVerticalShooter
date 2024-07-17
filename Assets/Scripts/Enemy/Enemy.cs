using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        private int _hp;
        protected float _speedMovement;

        protected Enemy()
        {
            var enemySettings = ServiceLocator.Get<GameConfig>().EnemyFactoryConfig;
            _speedMovement = Random.Range(enemySettings.SpeedMin, enemySettings.SpeedMax);
        }
        abstract public void Move();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle") {
                //EventBus.OnFinishLineReached
            }
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
    }
}
