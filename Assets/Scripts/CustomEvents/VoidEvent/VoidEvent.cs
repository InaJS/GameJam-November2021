using CustomEvents.BaseEvent;
using UnityEngine;

namespace CustomEvents.VoidEvent
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/VoidEvent", fileName = "NewVoidEvent")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}