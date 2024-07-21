using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ObjectPool;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Enemy.EnemyTypes;
using UnityEngine;

namespace Assets.Scripts.Shooting.AttackModes
{
    public class AutoShooting : AttackMode
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private ParticleSystem _shootParticle;

        private BulletObjectPool _pool;
        private EventBus _eventBus;
        private float _shootTimeout;
        private float _searchTimeout;

        private EnemyBase _currentTarget;

        public override void Init()
        {
            base.Init();
            _pool = ServiceLocator.Get<BulletObjectPool>();
            _eventBus = ServiceLocator.Get<EventBus>();
            _eventBus.OnReadyToShoot.Subscribe(GetShot);
        }

        public override void Shoot()
        {
            _shootTimeout -= Time.deltaTime;
            if (_shootTimeout < 0 && CheckTargetAlive())
            {
                _eventBus.OnShootTimeOuted.Trigger(_currentTarget.transform.position);
                _shootTimeout = _speedShooting;
            }
        }

        private void GetShot(Vector3 targetPosition)
        {
            _shootParticle.Play();
            _pool.GetObject(_spawnPoint.position, targetPosition);
        }

        public void SearchEnemy()
        {
            _searchTimeout -= Time.deltaTime;
            if (_searchTimeout < 0 && !CheckTargetAlive())
            {
                var hitEnemies = Physics2D.OverlapCircleAll(transform.position, _range, enemyLayer);
                if (hitEnemies.Length > 0)
                {
                    _shootTimeout = _speedShooting;
                    SetAtClosestEnemy(hitEnemies);
                }
                _searchTimeout = 0.2f;
            }

        }

        private void SetAtClosestEnemy(Collider2D[] enemies)
        {
            Collider2D closestEnemy = FindClosestEnemy(enemies);

            if (closestEnemy != null)
            {
                _currentTarget = closestEnemy.GetComponent<EnemyBase>();
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
        private bool CheckTargetAlive() => (_currentTarget != null) ? !_currentTarget.IsDead : false;
    }
}
