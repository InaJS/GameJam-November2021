using _Code.CustomEvents.BaseEvent;
using UnityEngine;

namespace _Code.CustomEvents.TransformEvent
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/TransformEvent", fileName = "NewTransformEvent")]
    public class TransformEvent : BaseGameEvent<Transform>
    {
    }
}