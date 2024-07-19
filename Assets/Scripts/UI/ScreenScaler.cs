using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    RectTransform _rectTransform;

    private float _screenHeight = Screen.height;
    private float _screenWidth = Screen.width;
    private Vector2 _anchorsMin;
    private Vector2 _anchorsMax;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        SetAnchorsPosition();
    }

    private void SetAnchorsPosition()
    {
        float xMin;
        float xMax;
        bool mobileResolution = (_screenWidth / _screenHeight <= 0.5625f); //0.5625 = 9/16
        
        if (mobileResolution)
        {
            xMin = 0;
            xMax = 1;
        }
        else
        {
            CalculateAnchorsForOtherDevices(out xMin, out xMax);
        }

        _rectTransform.anchorMin = new Vector2(xMin, 0);
        _rectTransform.anchorMax = new Vector2(xMax, 1);
    }

    private void CalculateAnchorsForOtherDevices(out float minX, out float maxX)
    {
        float targetWidth = _screenHeight * 0.5625f;
        float ratioTargetWidthToCurrentWidth = targetWidth / _screenWidth;
        float halfOfRatio = ratioTargetWidthToCurrentWidth * 0.5f;
        minX = 0.5f - halfOfRatio; //0.5 - middle of screen
        maxX = 0.5f + halfOfRatio; 
    }
}
