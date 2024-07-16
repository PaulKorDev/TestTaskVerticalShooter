using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Architecture.EventBus
{
    public class CustomEvent : BaseCustomEvent<Action>
    {
        public void Trigger()
        {
            var tempListeners = _listeners.Values.ToList();

            foreach (var listener in tempListeners) 
                listener.Listener.Invoke();
        }
    }
    public class CustomEvent<T1> : BaseCustomEvent<Action<T1>>
    {
        public void Trigger(T1 arg)
        {
            foreach (var listener in _listeners)
            {
                listener.Value.Listener.Invoke(arg);
            }
        }
    }
    public class CustomEvent<T1, T2> : BaseCustomEvent<Action<T1, T2>>
    {
        public void Trigger(T1 arg, T2 arg2)
        {
            foreach (var listener in _listeners)
            {
                listener.Value.Listener.Invoke(arg, arg2);
            }
        }
    }
    public class CustomEvent<T1, T2, T3> : BaseCustomEvent<Action<T1, T2, T3>>
    {
        public void Trigger(T1 arg, T2 arg2, T3 arg3)
        {
            foreach (var listener in _listeners)
            {
                listener.Value.Listener.Invoke(arg, arg2, arg3);
            }
        }
    }
    public class CustomEvent<T1, T2, T3, T4> : BaseCustomEvent<Action<T1, T2, T3, T4>>
    {
        public void Trigger(T1 arg, T2 arg2, T3 arg3, T4 arg4)
        {
            foreach (var listener in _listeners)
            {
                listener.Value.Listener.Invoke(arg, arg2, arg3, arg4);
            }
        }
    }
}
