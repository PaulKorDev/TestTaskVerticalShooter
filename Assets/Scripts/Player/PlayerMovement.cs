using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : IService
    {
        private Rigidbody2D _playerRgb;
        private float _speed;

        private float _leftLimit;
        private float _rightLimit;
        private float _bottomLimit;
        private float _topLimit;

        private float _axisX;
        private float _axisY;

        public PlayerMovement()
        {
            var player = ServiceLocator.Get<Player>();

            _playerRgb = player.GetComponent<Rigidbody2D>();
            _speed = player.GetSpeed();
        }

        public void InputHandler()
        {
            GetInputAxis(out _axisX, out _axisY);
        }
        public void Move()
        {
            _playerRgb.velocity = new Vector3(_axisX, _axisY, 0).normalized * _speed * Time.fixedDeltaTime;
        }

        private void GetInputAxis(out float x, out float y)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }

    }

}

