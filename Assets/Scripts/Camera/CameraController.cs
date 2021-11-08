using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using VectorExtensions;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _distanceFromTarget;
    [SerializeField] private float _cameraLift;
    [SerializeField] private float _cameraOvershoot;
    [Range(1.0f, 10.0f)] [SerializeField] private float _cameraLerpSpeed;
    [Range(0.01f, 0.1f)] [SerializeField] private float _cameraRelaxSpeed;
    private Transform _targetToFollow;
    private Vector3 _overshootVector;

    public void SetTargetToFollow(Transform target)
    {
        _targetToFollow = target;
    }

    void LateUpdate()
    {
        if (_targetToFollow == null)
        {
            throw new NullReferenceException("Camera does not have a target to follow");
        }

        AdjustCameraPosition();
    }

    private void AdjustCameraPosition()
    {
        // the offset below might not even be necessary, we'll see as time goes
        Vector3 isometricOffset = Vector3Isometric.CameraIso * _distanceFromTarget;
        Vector3 birdsEyeViewOffset = Vector3.up * _cameraLift;

        Vector3 snapTarget = _targetToFollow.position + isometricOffset + birdsEyeViewOffset;
        Vector3 finalTarget = snapTarget + _overshootVector;
        
        
        if (_overshootVector.magnitude < 0.5f * _cameraOvershoot)
        {
            _overshootVector = Vector3.Lerp(_overshootVector, Vector3.zero, _cameraRelaxSpeed * Time.deltaTime);
        }

        // transform.position = snapTarget;
        transform.position = Vector3.Lerp(snapTarget, finalTarget, _cameraLerpSpeed * Time.deltaTime);
    }

    public void UpdateCameraOvershoot(Vector3 direction)
    {
        _overshootVector = direction * _cameraOvershoot;
    }
}