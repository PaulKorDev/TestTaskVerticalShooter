using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speedMovement;

        private PlayerMovement _movement;

        private void Awake()
        {
            var rgb = gameObject.GetComponent<Rigidbody2D>();
            _movement = new PlayerMovement(rgb);
        }

        public void FixedUpdate()
        {
            _movement.Move(_speedMovement);
        }
    }
}
