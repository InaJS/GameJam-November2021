using System;
using _Code.CustomEvents.TransformEvent;
using UnityEngine;
using VectorExtensions;

namespace PlayerMovement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementPrototype : MonoBehaviour
    {
        [SerializeField] private TransformEvent _subscribeToCamera;
        [SerializeField] private Vector3Event _passInputToCamera;
        [Range(1.0f,10.0f)] [SerializeField] private float _playerSpeed = 5.0f;
        [Range(5.0f,20.0f)] [SerializeField] private float _playerJump = 15.0f;
        
        private Rigidbody _body;
        private Vector3 _registeredMovement = new Vector3();
        private Vector3 _isoMovement = new Vector3();
        
        private void Awake()
        {
            _body = this.GetComponent<Rigidbody>();
            _subscribeToCamera.Raise(this.gameObject.transform);
        }

        private void Update()
        {
            _registeredMovement.x = Input.GetAxis("Horizontal");
            _registeredMovement.z = Input.GetAxis("Vertical");
            
            if (Input.GetKey("space") && this.transform.localPosition.y <= 0.6f)
            {
                this._body.AddForce(_playerJump * Vector3.up);
            }

            _isoMovement = _registeredMovement.ConvertCartesianToIso().normalized;
            
            _passInputToCamera.Raise(_isoMovement);
            
            this.transform.position += _isoMovement * _playerSpeed * Time.deltaTime;
        }
    }
}
