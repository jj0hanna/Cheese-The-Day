using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject confirmationBox;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject controlsMenu;

    private void Awake()
    {
        AudioManager.StopSound("GameMusic");
    }

    public void StartGame()
    { 
        SceneManager.LoadScene("IntroScene");
    }

    public void PlayDownSound()
    {
        AudioManager.PlaySound("ClickDown");
    }

    public void PlayUpSound()
    {
        AudioManager.PlaySound("ClickUp");
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
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
