namespace _Code.CustomEvents.BaseEvent
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}