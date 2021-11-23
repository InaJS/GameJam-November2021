using UnityEngine;

namespace Enemies.EnemyAttacks
{
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
}
