using UnityEngine;

namespace Assets.Scripts.Enemy.EnemyTypes
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class DefaultEnemy : EnemyBase
    {
        private Rigidbody2D _enemyRgb;
        public DefaultEnemy() : base() { }

        private void Awake()
        {
            _enemyRgb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Move();
        }
        public override void Move()
        {
            _enemyRgb.velocity = Vector2.down * _speedMovement * Time.fixedDeltaTime;
        }
    }
}
