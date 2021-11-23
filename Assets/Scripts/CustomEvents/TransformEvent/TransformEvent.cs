using CustomEvents.BaseEvent;
using UnityEngine;

namespace CustomEvents.TransformEvent
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/TransformEvent", fileName = "NewTransformEvent")]
    public class TransformEvent : BaseGameEvent<Transform>
    {
    }
}