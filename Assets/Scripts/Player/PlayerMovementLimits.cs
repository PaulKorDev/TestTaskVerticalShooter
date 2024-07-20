using Assets.Scripts.Architecture.ServiceLocator;
using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMovementLimits : MovementLimits
    {
        private float _halfSizeOfPlayerY = ServiceLocator.Get<Player>().GetComponentInChildren<SpriteRenderer>().bounds.size.y * 0.5f;
        private float _halfSizeOfPlayerX = ServiceLocator.Get<Player>().GetComponentInChildren<SpriteRenderer>().bounds.size.x * 0.5f;
        public PlayerMovementLimits() : base() { }
        protected override float GetTopLimit()
        {
            var finishLine = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Transform>();
            return finishLine.position.y - _halfSizeOfPlayerY;
        }
        protected override float GetBottomLimit() {
            return base.GetBottomLimit() + _halfSizeOfPlayerY;
        }
        protected override float GetLeftLimit()
        {
            return base.GetLeftLimit() + _halfSizeOfPlayerX;
        }
        protected override float GetRightLimit()
        {
            return base.GetRightLimit() - _halfSizeOfPlayerX;
        }
    }
}
