using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject creditCanvas;
    [SerializeField]
    private GameObject optionCanvas;

    [SerializeField]
    private Button newGameButton;
    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private Button creditsButton;
    [SerializeField]
    private Button continueButton;

    public void NewGame()
    {
        SceneManager.LoadScene("Demo Level");
    }

    public void Options()
    {
        optionCanvas.SetActive(true);
        newGameButton.interactable = false;
        optionsButton.interactable = false;
        creditsButton.interactable = false;
        continueButton.interactable = false;
    }

    public void CloseOptions()
    {
        optionCanvas.SetActive(false);
        newGameButton.interactable = true;
        optionsButton.interactable = true;
        creditsButton.interactable = true;
        continueButton.interactable = true;
    }

    public void Credits()
    {
        creditCanvas.SetActive(true);
        newGameButton.interactable = false;
        optionsButton.interactable = false;
        creditsButton.interactable = false;
        continueButton.interactable = false;
    }

    public void CloseCredits()
    {
        creditCanvas.SetActive(false);
        newGameButton.interactable = true;
        optionsButton.interactable = true;
        creditsButton.interactable = true;
        continueButton.interactable = true;
    }

}
