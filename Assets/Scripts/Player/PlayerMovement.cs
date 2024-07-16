using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement
    {
        private float _speedMovement;
        private Transform _player;

        public PlayerMovement(float speed, Transform player)
        {
            _speedMovement = speed;
            _player = player;
        }

        public void Move()
        {
          
        }

    }
}
