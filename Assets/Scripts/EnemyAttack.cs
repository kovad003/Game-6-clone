using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// AUTHOR: @Joona H.
/// Last modified: 1 Dec 2022 by @Joona H.
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    /* EXPOSED FIELDS: */
    [SerializeField] private float forceModifier = 15;
    
    /* HIDDEN FIELDS: */
    private Rigidbody2D rigidbody;
    
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("kick back");
            rigidbody.velocity = forceModifier * -1 * rigidbody.velocity.normalized;
            // TakeDamage(20); 
            // TODO dmg should be collected from Enemy
            // TakeDamage(other.GetDamageValue); 
        }
    }
}
