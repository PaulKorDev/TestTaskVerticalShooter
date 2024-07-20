using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Shooting.AttackModes;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : IService
    {
        private Rigidbody2D _playerRgb;
        private Player _player;
        private EventBus _eventBus;
        private float _speed;

        private float _leftLimit;
        private float _rightLimit;
        private float _bottomLimit;
        private float _topLimit;

        private float _axisX;
        private float _axisY;

        public PlayerMovement()
        {
            _player = ServiceLocator.Get<Player>();
            _eventBus = ServiceLocator.Get<EventBus>();
            _eventBus.OnEnemyFound.Subscribe(RotateToEnemy);

            _playerRgb = _player.GetComponent<Rigidbody2D>();
            _speed = _player.GetSpeed();
        }

        public void InputHandler()
        {
            GetInputAxis(out _axisX, out _axisY);
        }
        public void Move()
        {
            //_playerRgb.velocity = new Vector3(_axisX, _axisY, 0).normalized * _speed * Time.fixedDeltaTime;
            _player.transform.Translate(new Vector3(_axisX, _axisY, 0).normalized * _speed * Time.deltaTime, Space.World);
        }

        private void GetInputAxis(out float x, out float y)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
     
        private void RotateToEnemy(Vector3 enemyPosition)
        {
            Vector3 direction = enemyPosition - _player.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            _player.transform.DORotate(new Vector3(0, 0, angle), 0.1f)
                .OnComplete(() => _eventBus.OnReadyToShoot.Trigger(enemyPosition));
        }

    }

}

