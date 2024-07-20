using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Configs;
using DG.Tweening;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : IService
    {
        private Player _player;
        private MovementLimits _playerMovementLimits;
        private EventBus _eventBus;
        private float _speed;

        private float _axisX;
        private float _axisY;

        public PlayerMovement(MovementLimits playerMovementLimits)
        {
            _player = ServiceLocator.Get<Player>();
            _playerMovementLimits = playerMovementLimits;
            _eventBus = ServiceLocator.Get<EventBus>();
            _eventBus.OnShootTimeOuted.Subscribe(RotateToEnemy);
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
        private void RotateToEnemy(Vector3 enemyPosition)
        {
            Vector3 direction = enemyPosition - _player.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            _player.transform.DORotate(new Vector3(0, 0, angle), 0.1f)
                .OnComplete(() => _eventBus.OnReadyToShoot.Trigger(enemyPosition));
        }

    }

}

