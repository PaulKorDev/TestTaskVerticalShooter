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
        private float _shootTimeout;
        private float _searchTimeout;
        private Vector3 _direction;



        public override void Shoot(Vector3 targetPosition)
        {
            ServiceLocator.Get<BulletObjectPool>().GetObject(_spawnPoint.position, targetPosition);
        }

        public void SearchAndShoot()
        {
            _shootTimeout -= Time.deltaTime;
            _searchTimeout -= Time.deltaTime;
            if (_shootTimeout < 0)
            {
                if (_searchTimeout < 0)
                {
                    Collider2D[] hitEnemies;
                    hitEnemies = Physics2D.OverlapCircleAll(transform.position, _range, enemyLayer);
                    if (hitEnemies.Length > 0)
                    {
                        _shootTimeout = _speedShooting;
                        ShootAtClosestEnemy(hitEnemies);
                    }
                    _searchTimeout = 0.05f;
                }
            }
        }

        private void ShootAtClosestEnemy(Collider2D[] enemies)
        {
            Collider2D closestEnemy = FindClosestEnemy(enemies);

            if (closestEnemy != null)
            {
                _direction = closestEnemy.transform.position;
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
