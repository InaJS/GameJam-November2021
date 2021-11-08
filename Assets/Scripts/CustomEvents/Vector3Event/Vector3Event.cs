using _Code.CustomEvents.BaseEvent;
using UnityEngine;

namespace _Code.CustomEvents.TransformEvent
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/Vector3Event", fileName = "NewVector3Event")]
    public class Vector3Event : BaseGameEvent<Vector3>
    {
    }
}