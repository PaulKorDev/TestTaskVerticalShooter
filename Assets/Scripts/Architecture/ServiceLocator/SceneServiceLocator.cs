using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        [SerializeField] private GameConfig _settings;
        public void RegisterAllServices()
        {
            //here register services
            RegisterSettings();
        }

        private void RegisterSettings() => ServiceLocator.Register(_settings);

        private void OnDestroy()
        {
            //here unregister services
            ServiceLocator.Unregister(_settings);
        }
    }
}
