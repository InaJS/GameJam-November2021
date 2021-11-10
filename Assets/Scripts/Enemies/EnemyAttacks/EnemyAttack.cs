using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected float attackRange = 5f;
    [SerializeField] protected float attackCooldown = 2f;
    
    public float AttackRange => attackRange;
    public float AttackCooldown => attackCooldown;
    
    public virtual void DoAttack(){}
    public virtual bool CanAttack()
    {
        return false;
    }
}
