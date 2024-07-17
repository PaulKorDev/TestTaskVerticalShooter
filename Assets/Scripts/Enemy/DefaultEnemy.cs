using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DefaultEnemy : Enemy
    {
        private Rigidbody2D _enemyRgb;
        public DefaultEnemy() : base() { }

        private void Awake()
        {
            _enemyRgb = GetComponent<Rigidbody2D>();
        }
        public override void Move()
        {
            _enemyRgb.velocity = Vector2.down * _speedMovement * Time.fixedDeltaTime;
        }
    }
}
