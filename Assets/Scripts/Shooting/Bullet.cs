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

        private Rigidbody2D _bulletRgb;

        private void Start()
        {
            _bulletRgb = GetComponent<Rigidbody2D>();
            _speed = ServiceLocator.Get<GameConfig>().PlayerAttackConfig.BulletSpeed;
        }

        public void Init(Vector3 targetPosition)
        {
            _target = targetPosition;
            _damage = ServiceLocator.Get<AttackMode>().GetDamage();

            Fly();
        }

        public int GetDamage() => _damage;

        public void Fly()
        {
            transform.DOMove(_target, _speed);
        }
    }
}
