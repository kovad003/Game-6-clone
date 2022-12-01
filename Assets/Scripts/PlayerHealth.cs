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
    
    [Header("UI: ")]
    [Tooltip("Attach the game over canvas here!")]
    [SerializeField] private Canvas gameOverCanvas;

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
        Debug.Log("You have DIED!");
        // TODO Game Over canvas should be enabled here
        // gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAiming>().enabled = false;
    }
}
