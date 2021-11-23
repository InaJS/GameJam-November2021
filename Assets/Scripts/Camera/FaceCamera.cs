using UnityEngine;

namespace Camera
{
   public class FaceCamera : MonoBehaviour
   {
      private Transform mainCameraTransform;

      private void Start()
      {
         mainCameraTransform = UnityEngine.Camera.main.transform;
      }

      private void LateUpdate()
      {
         //This will make whatever has this script on it always face the camera *magic*
         var camRotation = mainCameraTransform.rotation;
         transform.LookAt(transform.position + camRotation * Vector3.forward, camRotation * Vector3.up);
      }
   }
}
