using Assets.Scripts.Architecture.ServiceLocator;
using System;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    public class ScreenLimits : IService
    {
        private float _screenHeight = Screen.height;
        private float _screenWidth = Screen.width;

        private Camera _cachedCamera;

        //ScreenPoints
        private Vector3 _bottomLeftPointOfScreen;
        private Vector3 _topRightPointOfScreen;

        //Ratio
        public float LeftScreenRatioLimit { get; private set; }
        public float RightScreenRatioLimit { get; private set; }
        public float TopScreenRatioLimit { get; private set; }
        public float BottomScreenRatioLimit { get; private set; }

        //Vector3
        public float LeftScreenPositionLimit { get; private set; }
        public float RightScreenPositionLimit { get; private set; }
        public float TopScreenPositionLimit { get; private set; }
        public float BottomScreenPositionLimit { get; private set; }

        public ScreenLimits()
        {
            _cachedCamera = Camera.main;

            SetHorizontalRatioLimits();
            SetVerticalRatioLimits();
            SetVectorScreenLimits();
        }
        private void SetVectorScreenLimits()
        {
            SetPointsOfScreen();
            SetVerticalPositionLimits();
            SetHorizontalPositionLimits();
        }

        private void SetVerticalRatioLimits()
        {
            TopScreenRatioLimit = 1;
            BottomScreenRatioLimit = 0;
        }
        private void SetHorizontalRatioLimits()
        {
            bool mobileResolution = (_screenWidth / _screenHeight <= 0.5625f); //0.5625 = 9/16

            if (mobileResolution)
            {
                LeftScreenRatioLimit = 0;
                RightScreenRatioLimit = 1;
            }
            else
            {
                CalculateRatioForOtherDevices();
            }
        }
        private void SetVerticalPositionLimits()
        {
            TopScreenPositionLimit = _topRightPointOfScreen.y;
            BottomScreenPositionLimit = _bottomLeftPointOfScreen.y;
        }
        private void SetHorizontalPositionLimits()
        {
            LeftScreenPositionLimit = _bottomLeftPointOfScreen.x;
            RightScreenPositionLimit = _topRightPointOfScreen.x;
        }
        private void SetPointsOfScreen()
        {
            float leftOffset = LeftScreenRatioLimit * _screenWidth;
            float rightOffset = RightScreenRatioLimit * _screenWidth;
            float topOffset = TopScreenRatioLimit * _screenHeight;
            float bottomOffset = BottomScreenRatioLimit * _screenHeight;

            _bottomLeftPointOfScreen = _cachedCamera.ScreenToWorldPoint(new Vector3(leftOffset, bottomOffset));
            _topRightPointOfScreen = _cachedCamera.ScreenToWorldPoint(new Vector2(rightOffset, topOffset));

        }
        private void CalculateRatioForOtherDevices()
        {
            float targetWidth = _screenHeight * 0.5625f;
            float ratioTargetWidthToCurrentWidth = targetWidth / _screenWidth;
            float halfOfRatio = ratioTargetWidthToCurrentWidth * 0.5f;
            LeftScreenRatioLimit = 0.5f - halfOfRatio; //0.5 - middle of screen
            RightScreenRatioLimit = 0.5f + halfOfRatio;
        }
    }
}
