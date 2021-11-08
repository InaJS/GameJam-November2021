using System.Collections.Generic;
using UnityEngine;

namespace _Code.CustomEvents.BaseEvent
{
    public class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();
        [SerializeField] private bool useInspectorValue;
        [SerializeField] private T inspectorValue;

        public void Raise(T item)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                if (useInspectorValue)
                {
                    item = inspectorValue;
                }
                eventListeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }
    
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }
    }
}
