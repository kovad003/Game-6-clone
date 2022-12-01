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
    [SerializeField] private float kbForceModifier = 15;
    [SerializeField] private float damage = 5.0f;
    
    /* HIDDEN FIELDS: */
    private Rigidbody2D rigidbody;
    private PlayerHealth playerHealth;
    
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("kick back");
            rigidbody.velocity = kbForceModifier * -1 * rigidbody.velocity.normalized;
            playerHealth.TakeDamage(damage);
        }
    }
}
