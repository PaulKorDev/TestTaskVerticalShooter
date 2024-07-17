using Assets.Scripts.Architecture.EventBus;
using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class LoseAndWinWindow : MonoBehaviour
    {
        [SerializeField] GameObject LoseWindow;
        [SerializeField] GameObject WinWindow;

        private void Start()
        {
            ServiceLocator.Get<EventBus>().OnPlayerLost.Subscribe(ShowLoseWindow);
            ServiceLocator.Get<EventBus>().OnPlayerWon.Subscribe(ShowWinWindow);

            ServiceLocator.Get<EventBus>().GameRestarted.Subscribe(HideLoseWindow);
            ServiceLocator.Get<EventBus>().GameRestarted.Subscribe(HideWinWindow);
        }

        private void ShowLoseWindow()
        {
            LoseWindow.SetActive(true);
        }
        private void ShowWinWindow()
        {
            WinWindow.SetActive(true);
        }
        private void HideLoseWindow()
        {
            LoseWindow.SetActive(false);
        }
        private void HideWinWindow()
        {
            WinWindow.SetActive(false);
        }

        public void ButtonRestartClicked()
        {
            ServiceLocator.Get<EventBus>().OnButtonRestartClicked.Trigger();
        }
    }
}
