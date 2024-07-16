using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speedMovement;

        private PlayerMovement _movement;

        private void Awake()
        {
            _movement = new PlayerMovement(_speedMovement, transform);
        }

        public void Update()
        {
            _movement.Move();
        }
    }
}
