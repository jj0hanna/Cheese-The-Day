using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject confirmationBox;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject controlsMenu;

    public bool pauseMenuActive = false;
    
    public void ShowPauseMenu()
    {
        gameObject.SetActive(true);
        pauseMenuActive = true;
    }

    public void HidePauseMenu()
    {
        gameObject.SetActive(false);
        settingsMenu.SetActive(false);
        confirmationBox.SetActive(false);
        pauseMenuActive = false;
        controlsMenu.SetActive(false);
    }
    
    public void ShowConfirmationBox()
    {
        confirmationBox.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HideConfirmationBox()
    {
        confirmationBox.SetActive(false);
        gameObject.SetActive(true);
    }
    
    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HideSettings()
    {
        settingsMenu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ShowControls()
    {
        controlsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HideControls()
    {
        controlsMenu.SetActive(false);
        gameObject.SetActive(true);
    }
    
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
