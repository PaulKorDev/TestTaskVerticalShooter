using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using DG.Tweening;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : IService
    {
        private Rigidbody2D _playerRgb;
        private Player _player;
        private float _speed;

        private float _axisX;
        private float _axisY;

        public PlayerMovement()
        {
            _player = ServiceLocator.Get<Player>();

            _playerRgb = _player.GetComponent<Rigidbody2D>();
            _speed = _player.GetSpeed();
        }

        public void InputHandler()
        {
            GetInputAxis(out _axisX, out _axisY);
        }
        public void Move()
        {

            _player.transform.Translate(GetMovementPosition(), Space.World);
        }

        private void GetInputAxis(out float x, out float y)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
     

        private Vector3 GetMovementPosition()
        {
            Vector3 movementPos = new Vector3(_axisX, _axisY, 0).normalized * (_speed * Time.deltaTime);
            if (PlayerCanMoveThere(movementPos))
                return movementPos;
             else 
                return Vector3.zero;
        }

        private bool PlayerCanMoveThere(Vector3 movementPos)
        {
            throw new NotImplementedException();
        }
    }

}

