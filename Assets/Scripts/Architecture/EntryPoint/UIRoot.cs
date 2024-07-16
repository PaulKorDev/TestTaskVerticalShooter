using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

namespace Assets.Scripts.Architecture.EntryPoint
{
    public sealed class UIRoot : MonoBehaviour, IService
    {
        [SerializeField] private GameObject _loadingScreen;

        private void Awake()
        {
             HideLoadingScreen();   
        }

        public void HideLoadingScreen() => _loadingScreen.SetActive(false);
        public void ShowLoadingScreen() => _loadingScreen.SetActive(true);
    }
}
