using Assets.Scripts.Architecture.ServiceLocator;

namespace Assets.Scripts.Configs
{
    public class MovementLimits
    {
        private ScreenLimits _screenLimits;

        public float LeftLimit { get; private set;}
        public float RightLimit {get; private set;}
        public float BottomLimit {get; private set;}
        public float TopLimit {get; private set;}

        public MovementLimits()
        {
            _screenLimits = ServiceLocator.Get<ScreenLimits>();
            SetMovementLimits();
        }

        private void SetMovementLimits()
        {
            LeftLimit = GetLeftLimit();
            RightLimit = GetRightLimit();
            TopLimit = GetTopLimit();
            BottomLimit = GetBottomLimit();
        }

        virtual protected float GetLeftLimit() => _screenLimits.LeftScreenPositionLimit;
        virtual protected float GetRightLimit() => _screenLimits.RightScreenPositionLimit;
        virtual protected float GetTopLimit() => _screenLimits.TopScreenPositionLimit;
        virtual protected float GetBottomLimit() => _screenLimits.BottomScreenPositionLimit;
    }
}
