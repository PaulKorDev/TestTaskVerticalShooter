using UnityEngine;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public class SceneServiceLocator : MonoBehaviour
    {
        public void RegisterAllServices()
        {
            //here register services
        }

        private void OnDestroy()
        {
            //here unregister services
        }
    }
}
