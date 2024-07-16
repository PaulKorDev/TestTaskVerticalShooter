using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Architecture.EntryPoint
{
    public sealed class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private UIRoot _uiRoot;
        private CoroutineObj _coroutine;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStart()
        {
            Application.targetFrameRate = 60;

            if (SystemInfo.deviceType == DeviceType.Handheld)
                Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint() {
            CreateLoadingScreen();
            CreateCoroutineObject();
        }

        //Chek current scene and load first
        private void RunGame()
        {
            _coroutine.StartCoroutine(LoadAndStartFirstScreen());
        }

        private IEnumerator LoadAndStartFirstScreen()
        {

            _uiRoot.ShowLoadingScreen();
            yield return SceneLoader.LoadScene(ScenesNames.GAMEPLAY);
            
        }

        //Loading screen it's pre-first screen, usualy with logo or loading progress bar
        private void CreateLoadingScreen()
        {
            var prefabUIRoot = Resources.Load<GameObject>(PrefabsPaths.UIROOT);
            _uiRoot = GameObject.Instantiate(prefabUIRoot).GetComponent<UIRoot>();
            GameObject.DontDestroyOnLoad(_uiRoot.gameObject);

            ServiceLocator.ServiceLocator.Register(_uiRoot);

        }
        private void CreateCoroutineObject()
        {
            _coroutine = new GameObject("[COROUTINE]").AddComponent<CoroutineObj>();
            GameObject.DontDestroyOnLoad(_coroutine.gameObject);

            ServiceLocator.ServiceLocator.Register(_coroutine);
        }

    }
}
