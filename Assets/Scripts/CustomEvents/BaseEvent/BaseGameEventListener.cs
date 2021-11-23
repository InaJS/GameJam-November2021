using System;
using UnityEngine;
using UnityEngine.Events;

namespace CustomEvents.BaseEvent
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E _gameEvent;
        [SerializeField] private UER UnityEventResponse;

        private void OnEnable()
        {
            _gameEvent?.RegisterListener(this);
            // foreach (var singleEvent in GameEvent)
            // {
            //     singleEvent.RegisterListener(this);
            // }
        }

        private void OnDisable()
        {
            _gameEvent?.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            UnityEventResponse?.Invoke(item);
        }
    }

    [Serializable]
    public struct EventAndResponse<T, E, UER> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        public E gameEvent;
        public UER UnityEventResponse;
    }

}