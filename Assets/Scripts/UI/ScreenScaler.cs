using Assets.Scripts.Configs;
using UnityEngine;

public class ScreenScaler : MonoBehaviour
{
    RectTransform _rectTransform;
    ScreenLimits _screenLimits;

    public void Init(ScreenLimits screenLimits)
    {
        _rectTransform = GetComponent<RectTransform>();
        _screenLimits = screenLimits;

        SetAnchorsPosition();
    }

    private void SetAnchorsPosition()
    {
        _rectTransform.anchorMin = new Vector2(_screenLimits.LeftScreenRatioLimit, _screenLimits.BottomScreenRatioLimit);
        _rectTransform.anchorMax = new Vector2(_screenLimits.RightScreenRatioLimit, _screenLimits.TopScreenRatioLimit);
    }
}
