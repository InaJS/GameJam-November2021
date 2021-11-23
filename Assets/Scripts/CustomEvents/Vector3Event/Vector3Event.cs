using CustomEvents.BaseEvent;
using UnityEngine;

namespace CustomEvents.Vector3Event
{
    [CreateAssetMenu(menuName = "CustomScriptables/Events/Vector3Event", fileName = "NewVector3Event")]
    public class Vector3Event : BaseGameEvent<Vector3>
    {
    }
}