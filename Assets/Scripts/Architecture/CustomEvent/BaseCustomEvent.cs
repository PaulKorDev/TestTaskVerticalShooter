using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Architecture.EventBus
{
    public abstract class BaseCustomEvent<ACTION>
    {
        protected Dictionary<ACTION, ListenerWithPriority<ACTION>> _listeners = new();

        public void Subscribe(ACTION listener, int priority = 0)
        {
            ACTION key = listener;
            if (_listeners.ContainsKey(key)) 
                throw new System.Exception($"Subcribe error: listener {key} already subsribed");
            
            _listeners.Add(key, new ListenerWithPriority<ACTION>(listener, priority));
            SordDictionaryByPriority();
        }
        public void Unsubscribe(ACTION listener)
        {
            ACTION key = listener;
            if (!_listeners.ContainsKey(key))
                throw new System.Exception($"Unsubcribe error: listener {key} not subsribed");

            _listeners.Remove(key);
        }
        private void SordDictionaryByPriority()
        {
            var sortedListeners = _listeners.OrderByDescending(x => x.Value.Priority).ToDictionary(x => x.Key, x => x.Value);
            _listeners = sortedListeners;
        }
    }
}
