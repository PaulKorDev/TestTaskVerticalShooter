using System;
using System.Collections.Generic;

namespace Assets.Scripts.Architecture.ServiceLocator
{
    public interface IService { }

    public static class ServiceLocator
    {
        private static readonly Dictionary<string, IService> _services = new();

        public static void Register<T>(T service) where T : IService
        {
            string key = typeof(T).Name;

            if (_services.ContainsKey(key))
            {
                throw new Exception($"RegisterError: ServiceLocator already contains {key}");
            }

            _services.Add(key, service);
        }

        public static void Unregister<T>(T service) where T : IService
        {
            string key = typeof(T).Name;

            if (!_services.ContainsKey(key))
            {
                throw new Exception($"UnregisterError: ServiceLocator don't contains {key}");
            }

            _services.Remove(key);
        }

        public static T Get<T>() where T : IService
        {
            string key = typeof(T).Name;

            if (!_services.ContainsKey(key))
            {
                throw new Exception($"GetError: {key} not registered in ServiceLocator");
            }

            return (T)_services[key];
        }

    }
}
