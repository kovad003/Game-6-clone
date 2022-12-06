using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// AUTHOR: @Joona H.
/// Last modified: 1 Dec 2022 by @Daniel K.
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

    // @Daniel K - 01.12.2022
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rigidbody.AddForce(kbForceModifier * -1 * rigidbody.velocity.normalized, ForceMode2D.Impulse);
            playerHealth.TakeDamage(damage);
        }
    }

    // @Daniel K - 01.12.2022
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            rigidbody.AddForce(kbForceModifier * rigidbody.velocity.normalized, ForceMode2D.Impulse);
    }
    
}
