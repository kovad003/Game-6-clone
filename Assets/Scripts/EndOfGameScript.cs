using UnityEngine;

public class EndOfGameScript : MonoBehaviour
{
    [SerializeField] private GameObject gameWonCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    
    public void GameWon()
    {
        gameWonCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    
}
