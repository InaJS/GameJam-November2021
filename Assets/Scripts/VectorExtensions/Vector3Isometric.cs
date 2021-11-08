using UnityEngine;

namespace VectorExtensions
{
    public static class Vector3Isometric
    {
        public static readonly Vector3 Up = new Vector3(1.0f, 0.0f, 1.0f).normalized;
        public static readonly Vector3 Left = new Vector3(-1.0f, 0.0f, 1.0f).normalized;
        public static readonly Vector3 Down = new Vector3(-1.0f, 0.0f, -1.0f).normalized;
        public static readonly Vector3 Right = new Vector3(1.0f, 0.0f, -1.0f).normalized;
        
        public static readonly Vector3 CameraIso = new Vector3(-1,Mathf.Sqrt(2.0f),-1).normalized;
        
        /// <summary>
        /// Takes in a regular vector 3 and returns the corresponding vector in isometric perspective - always use this for player and/or enemy movement
        /// </summary>
        /// <param name="cartesianVector"> a vector in regular xyz coordinates </param>
        /// <returns>a new vector, now in proper isometric coordinates </returns>
        public static Vector3 ConvertCartesianToIso(this Vector3 cartesianVector)
        {
            Vector3 isoVector = new Vector3(0,0,0);

            isoVector += cartesianVector.x * Right;
            isoVector += cartesianVector.z * Up;
            isoVector += cartesianVector.y * Vector3.up;

            return isoVector;
        }
    }
}