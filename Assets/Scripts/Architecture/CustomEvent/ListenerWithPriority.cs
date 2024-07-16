using System;

namespace Assets.Scripts.Architecture.EventBus
{
    /// <summary>
    /// Used descending order (higher priority first)
    /// </summary>
    public class ListenerWithPriority<ACTION>
    {
        public readonly ACTION Listener;
        public readonly int Priority;

        public ListenerWithPriority(ACTION listener, int priority)
        {
            Listener = listener;
            Priority = priority;
        }
    }
   
}