using UnityEngine;

/// <summary>
/// AUTHOR: @Daniel K.
/// Last modified: 01 Dec 2022 by @Daniel K.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /* EXPOSED FIELDS: */
    [Header("PLAYER: ")] 
    [SerializeField] private float hitPoints = 100.0f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0.0f)
        {
            hitPoints = 0.0f;
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<EndOfGameScript>().GameOver();
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAiming>().enabled = false;
    }
}
