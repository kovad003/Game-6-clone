using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;
    [SerializeField]
    private GameObject optionsCanvas;
    [SerializeField]
    private GameObject winnerCanvas;
    [SerializeField]
    private GameObject gameOverCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           if (pauseCanvas.activeInHierarchy)
            {
                continueGame();
            } 
            else
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void continueGame()
    {
        optionsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void optionsMenu()
    {
        optionsCanvas.SetActive(true);
    }

    public void closeOptionsMenu()
    {
        optionsCanvas.SetActive(false);
    }

    public void quitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void restartLevel()
    {
        winnerCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        SceneManager.LoadScene("Demo Level");
    }
}
