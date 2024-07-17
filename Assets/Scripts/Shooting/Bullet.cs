using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Shooting.AttackModes;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private Vector3 _target;
        private Vector3 _direction;

        private float _leftEdge;
        private float _rightEdge;
        private float _topEdge;
        private float _bottomEdge;

        private Rigidbody2D _bulletRgb;

        public void Init()
        {
            _speed = ServiceLocator.Get<GameConfig>().PlayerAttackConfig.BulletSpeed;
            SetLimits();
            _bulletRgb = transform.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckBulletPosition();
        }

        public void SetTargetAndDamage(Vector3 targetPosition)
        {

            _target = targetPosition;
            _direction = targetPosition - transform.position;
            _damage = ServiceLocator.Get<AutoShooting>().GetDamage();
        }

        public int GetDamage() => _damage;

        public void Fly()
        {
            _bulletRgb.AddForce(_direction * _speed * Time.fixedDeltaTime);
        }

        private Vector3 CalculateNormalizedDirection(Vector3 targetPos)
        {
            _direction = targetPos - transform.position;
            float _distance = _direction.magnitude;
            return _direction / _distance;
        }

        private void SetLimits()
        {
            var edgesOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));

            _leftEdge = edgesOfScreen.x;
            _rightEdge = -edgesOfScreen.x;
            _topEdge = -edgesOfScreen.y;
            _bottomEdge = edgesOfScreen.y;
        }
        private void CheckBulletPosition()
        {
            if (OverBoundsX() || OverBoundsY())
                ServiceLocator.Get<EventBus>().OnBulletMissed.Trigger(this);
        }
        private bool OverBoundsX() => transform.position.x < _leftEdge || transform.position.x > _rightEdge;
        private bool OverBoundsY() => transform.position.y < _bottomEdge || transform.position.y > _topEdge;

    }
}
