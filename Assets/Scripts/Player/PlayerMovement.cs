using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Configs;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : IService
    {
        private Player _player;
        private MovementLimits _playerMovementLimits;
        private float _speed;

        private float _axisX;
        private float _axisY;

        public PlayerMovement(MovementLimits playerMovementLimits)
        {
            _player = ServiceLocator.Get<Player>();
            _playerMovementLimits = playerMovementLimits;
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
            Vector3 currentPosition = new Vector3(_axisX, _axisY, 0).normalized * (_speed * Time.deltaTime) + _player.transform.position;
            float movementPosX = Math.Clamp(currentPosition.x, _playerMovementLimits.LeftLimit, _playerMovementLimits.RightLimit);
            float movementPosY = Math.Clamp(currentPosition.y, _playerMovementLimits.BottomLimit, _playerMovementLimits.TopLimit);
            return new Vector3 (movementPosX, movementPosY) - _player.transform.position;
        }

    }

}

