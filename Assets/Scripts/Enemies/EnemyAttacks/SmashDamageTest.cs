using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashDamageTest : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private SmashAttack _smashAttack;
    private void OnCollisionEnter(Collision other)
    {
        _collider.enabled = false;

        if (!other.gameObject.TryGetComponent(out Health health)) return;
        
        health.DealDamage(_smashAttack.AttackDamage);
    }
}
