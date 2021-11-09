using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using PlayerMovement;
using UnityEngine;

public class StupidEnemy : Enemy
{
    [Header("Components")] [SerializeField]
    private SphereCollider _sphereCollider; //Code for OnTriggerEnter

    [Header("Enemy setup")] [SerializeField]
    private float aggroRange = 4f;

    [SerializeField] private float distToPlayerBeforeStopChasing = 8f;
    [SerializeField] private LayerMask whatToChase;

    [Header("Enemy attacks")] [SerializeField]
    private float attackRange = 1.5f;

    [SerializeField] private EnemyAttack myAttack;

    private PlayerMovementPrototype _playerMovementPrototype;
    private float distToPlayer;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange * 2);
    }

    private void Start()
    {
        //_sphereCollider.radius = aggroRange * 2; //Code for OnTriggerEneter
    }

    private void FixedUpdate()
    {
        //Test instead of using OnTriggerEnter
        if (_playerMovementPrototype == null)
        {
            CheckIfPlayerIsInRange();
        }

        //Early escapes
        if (_playerMovementPrototype == null) return;
        distToPlayer = Vector3.Distance(transform.position, _playerMovementPrototype.transform.position);
        if (distToPlayer > distToPlayerBeforeStopChasing) return;

        //Follow player
        transform.position = Vector3.MoveTowards(transform.position, _playerMovementPrototype.transform.position,
            movementSpeed * Time.fixedDeltaTime);

        //Attack player if in-range
        if (distToPlayer < attackRange)
        {
            //todo make myAttack into a List<EnemyAttack> so that we can have multiple attacks on the same enemy, then we just check if any ability is off cooldown and then we slam
            myAttack?.DoAttack(); //Do attack if we have assigned an attack
        }
    }

    //Basically same logic as OnTriggerEnter - Upside is that we don't need a big sphere collider obstructing OnMouseEnter events :^)
    private void CheckIfPlayerIsInRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, aggroRange * 2, whatToChase);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out PlayerMovementPrototype playerMovementPrototype))
            {
                _playerMovementPrototype = playerMovementPrototype;
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out PlayerMovementPrototype playerMovementPrototype)) return; //Early return
        
        _playerMovementPrototype = playerMovementPrototype; //Get a reference to the player
    }*/
}