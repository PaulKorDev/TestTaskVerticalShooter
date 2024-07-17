using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovement
    {
        private Rigidbody2D _playerRgb;

        private float _leftLimit;
        private float _rightLimit;
        private float _bottomLimit;
        private float _topLimit;

        public PlayerMovement(Rigidbody2D player)
        {
            _playerRgb = player.GetComponent<Rigidbody2D>();
        }

        public void Move(float speedMovement)
        {
            GetInputAxis(out float horizontal, out float vertical);

            _playerRgb.velocity = new Vector3(horizontal, vertical, 0).normalized * speedMovement * Time.fixedDeltaTime;
        }

        private void GetInputAxis(out float x, out float y)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }

    }

}

