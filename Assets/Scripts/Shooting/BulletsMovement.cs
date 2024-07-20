using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    public class BulletsMovement : MovementLimits
    {
        private Bullet _bullet;
        private Rigidbody2D _bulletRgb;
        private Vector3 _normalizedDirection;
        private float _bulletSpeed;

        public BulletsMovement(Bullet bullet, float speed)
        {
            _bullet = bullet;
            _bulletRgb = bullet.GetComponent<Rigidbody2D>();
            _bulletSpeed = speed;
        }

        public void Move()
        {
            _bulletRgb.AddForce(_normalizedDirection * _bulletSpeed * Time.fixedDeltaTime);
            CheckBulletPosition();
        }
        public void SetRotation(Vector3 targetPos)
        {
            CalculateNormalizedDirection(targetPos);
            float angle = Mathf.Atan2(_normalizedDirection.y, _normalizedDirection.x) * Mathf.Rad2Deg - 90;
            _bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        private void CalculateNormalizedDirection(Vector3 targetPos)
        {
            var direction = targetPos - _bullet.transform.position;
            float distance = direction.magnitude;
            _normalizedDirection = direction / distance;
        }

        private void CheckBulletPosition()
        {
            if (OverBoundsX() || OverBoundsY())
                ServiceLocator.Get<EventBus>().OnBulletMissed.Trigger(_bullet);
        }
        private bool OverBoundsX() => _bullet.transform.position.x < LeftLimit || _bullet.transform.position.x > RightLimit;
        private bool OverBoundsY() => _bullet.transform.position.y < BottomLimit || _bullet.transform.position.y > TopLimit;

        
    }
}
