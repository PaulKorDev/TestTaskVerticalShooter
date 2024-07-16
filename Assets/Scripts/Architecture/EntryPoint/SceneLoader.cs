using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Architecture.EntryPoint
{
    public class SceneLoader
    {
        private static IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(Scenes.TRANSIT);
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return new WaitForEndOfFrame();
        }
    }
}
