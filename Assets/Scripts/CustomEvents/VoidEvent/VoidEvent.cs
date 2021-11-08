using _Code.CustomEvents.BaseEvent;
using UnityEngine;

namespace _Code.CustomEvents.VoidEvent
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/VoidEvent", fileName = "NewVoidEvent")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}