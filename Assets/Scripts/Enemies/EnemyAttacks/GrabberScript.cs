using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberScript : EnemyAttack
{
    [SerializeField] private float howLongShouldWeGrab = 3f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private LayerMask WhatToGrab;
    [SerializeField] private Transform GrabberShootPoint;

    private Transform player;
    private Vector3 grabPoint;
    private SpringJoint joint;
    private float timeOfLastAttack;

    private bool drawLine = false;

    public override bool CanAttack()
    {
        if (Time.time > attackCooldown + timeOfLastAttack)
        {
            return true;
        }

        return false;
    }

    public override void DoAttack()
    {
        if (Time.time > attackCooldown + timeOfLastAttack)
        {
            StartGrabbing();
            Invoke(nameof(StopGrab), howLongShouldWeGrab);
            timeOfLastAttack = Time.time;
        }
    }

    private void Update()
    {
        if (player == null) return;
        if (Vector3.Distance(player.position, transform.position) > attackRange)
        {
            StopGrab();
        }
    }

    private void LateUpdate()
    {
        if (player == null) return;
        if (!drawLine) return;
        
        DrawGrabber();
    }

    private void StartGrabbing()
    {
        if (Physics.Raycast(GrabberShootPoint.transform.position, GrabberShootPoint.transform.TransformDirection(Vector3.up), out RaycastHit hit, Mathf.Infinity, WhatToGrab))
        {
            if (player == null)
            {
                player = hit.collider.gameObject.GetComponent<Transform>();
            }
            
            grabPoint = player.transform.position;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.connectedBody = rb;

            float distanceFromPoint = Vector3.Distance(player.position, grabPoint);

            joint.maxDistance = 0.01f;
            joint.minDistance = 0.01f;

            joint.spring = 28f;
            joint.damper = 7f;
            joint.massScale = 5f;
            lr.positionCount = 2;
            drawLine = true;
        }
    }

    private void StopGrab()
    {
        drawLine = false;
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawGrabber()
    {
        if (!joint) return;

        lr.SetPosition(0, GrabberShootPoint.position);
        lr.SetPosition(1, player.transform.position);
    }
    
}
