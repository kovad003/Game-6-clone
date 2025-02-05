using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AUTHOR: @Joona H.
/// Last modified: 1 Dec 2022 by @Joona H.
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    /* EXPOSED FIELDS: */
    public float maxHealth = 2;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    /* Enemy taking damage and deleting the gameObject on death */
   public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <=0)
        {
            Destroy(gameObject);
        }
    }
}
