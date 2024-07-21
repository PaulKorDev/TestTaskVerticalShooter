using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Shooting.AttackModes;
using UnityEngine;

namespace Assets.Scripts.Shooting
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        private float _speed;
        private Vector3 _target;

        private BulletsMovement _bulletsMovement;
        private Rigidbody2D _bulletRgb;

        public void Init()
        {
            _speed = ServiceLocator.Get<GameConfig>().PlayerAttackConfig.BulletSpeed;
            _bulletRgb = transform.GetComponent<Rigidbody2D>();
            _bulletsMovement = new BulletsMovement(this, _speed);
        }

        public void RotateToTargetAndSetDamage(Vector3 targetPosition)
        {
            _damage = ServiceLocator.Get<AutoShooting>().GetDamage();

            _target = targetPosition;
            _bulletsMovement.SetRotation(_target);

        }

        public void Fly()
        {
            _bulletsMovement.Move();
        }

        public int GetDamage() => _damage;

        
    }
}
