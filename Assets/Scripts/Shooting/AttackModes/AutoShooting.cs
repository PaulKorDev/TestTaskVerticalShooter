using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Architecture.ServiceLocator;
using System;
using UnityEngine;

namespace Assets.Scripts.Shooting.AttackModes
{
    public class AutoShooting : AttackMode
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private LayerMask enemyLayer;

        private BulletObjectPool _pool;

        private void Start()
        {
            _pool = ServiceLocator.Get<BulletObjectPool>();
        }
        public override void Shoot(Vector3 targetPosition)
        {
            _pool.GetObject(_spawnPoint.position, targetPosition);
        }
        public void SearchAndShoot()
        {

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, _range, enemyLayer);

            if (hitEnemies.Length > 0)
            {
                ShootAtClosestEnemy(hitEnemies);
            }
        }

        private void ShootAtClosestEnemy(Collider2D[] enemies)
        {
            Collider2D closestEnemy = FindClosestEnemy(enemies);

            if (closestEnemy != null)
            {
                Shoot(closestEnemy.transform.position);
            }
        }

        private Collider2D FindClosestEnemy(Collider2D[] enemies)
        {
            Collider2D closest = null;
            float closestDistance = Mathf.Infinity;
            foreach (Collider2D enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closest = enemy;
                    closestDistance = distance;
                }
            }
            return closest;
        }
    }
}
