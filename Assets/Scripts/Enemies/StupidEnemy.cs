using System.Collections.Generic;
using Enemies.EnemyAttacks;
using PlayerMovement;
using UnityEngine;

namespace Enemies
{
    public class StupidEnemy : Enemy
    {
        [Header("Enemy setup")] [SerializeField]
        private float aggroRange = 4f;

        [SerializeField] private float distToPlayerBeforeStopChasing = 8f;
        [SerializeField] private LayerMask whatToChase;

        [Header("Enemy attacks")] [SerializeField]
        private float attackRange = 1.5f;
    
        [SerializeField] private List<EnemyAttack> myAttacks;

        private PlayerMovementPrototype _playerMovementPrototype;
        private float distToPlayer;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, aggroRange * 2);
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
            Vector3 playerPos = _playerMovementPrototype.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos,
                movementSpeed * Time.fixedDeltaTime);
        
            //Look at player
            transform.LookAt(playerPos);

            foreach (EnemyAttack attack in myAttacks)
            {
                if (attack.CanAttack() && distToPlayer < attack.AttackRange)
                {
                    attack.DoAttack();
                }
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
    }
}