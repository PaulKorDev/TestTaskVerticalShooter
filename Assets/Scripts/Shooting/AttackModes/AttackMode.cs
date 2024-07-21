using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Shooting.AttackModes
{
    abstract public class AttackMode : MonoBehaviour, IService
    {
        protected int _damage;
        protected float _range;
        protected float _speedShooting;

        virtual public void Init()
        {
            PlayerAttackConfig _attackConfig = ServiceLocator.Get<GameConfig>().PlayerAttackConfig;

            _damage = _attackConfig.Damage;
            _range = _attackConfig.Range;
            _speedShooting = _attackConfig.Speed;
        }

        public int GetDamage() => _damage;

        public abstract void Shoot();
    }
}
