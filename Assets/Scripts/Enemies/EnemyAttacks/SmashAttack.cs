using System;
using System.Collections;
using UnityEngine;

public class SmashAttack : EnemyAttack
{
    [SerializeField] private GameObject objectToSmashDown;
    [SerializeField] private Collider objectToSmashCollider;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackSpeed = 10f;
    [SerializeField] private int attackDamage = 10;

    private float timeOfLastAttack = 0;
    private bool shouldAttack = false;
    private bool isAttacking = false;

    public int AttackDamage => attackDamage;

    private Vector3 objectToSmashDownStartPos;
    
    public override void DoAttack()
    {
        if (Time.time > attackCooldown + timeOfLastAttack)
        {
            shouldAttack = true;
            timeOfLastAttack = Time.time;
        }
    }

    private void Start()
    {
        objectToSmashDownStartPos = objectToSmashDown.transform.position;
    }

    private void Update()
    {
        if (isAttacking)
        {
            objectToSmashDown.transform.position =
                Vector3.MoveTowards(objectToSmashDown.transform.position, transform.position, attackSpeed * Time.deltaTime);
        }

        if (shouldAttack != true) return;
        objectToSmashDown.SetActive(true);
        Invoke(nameof(SetNotActiveAttack), 1f);
        isAttacking = true;
        shouldAttack = false;
    }

    void SetNotActiveAttack()
    {
        objectToSmashDown.SetActive(false);
        isAttacking = false;
        objectToSmashDown.transform.position = new Vector3(objectToSmashDown.transform.position.x,
            objectToSmashDownStartPos.y, objectToSmashDown.transform.position.z);
        objectToSmashCollider.enabled = true;
    }

}
