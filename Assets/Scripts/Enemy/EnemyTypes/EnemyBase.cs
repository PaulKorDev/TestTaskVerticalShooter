using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Shooting;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Enemy.EnemyTypes
{
    public abstract class EnemyBase : MonoBehaviour
    {
        protected int _hp;
        protected float _speedMovement;

        abstract public void Move();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle") {
                ServiceLocator.Get<EventBus>().OnFinishLineReached.Trigger(this);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var bullet = collision.gameObject.GetComponent<Bullet>();
            TakeDamage(bullet.GetDamage());
            ServiceLocator.Get<EventBus>().OnBulletHit.Trigger(bullet);

            
        }

        public abstract void InitEnemy();

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
                ServiceLocator.Get<EventBus>().OnEnemyDied.Trigger(this);
            }
        }
    }
}
