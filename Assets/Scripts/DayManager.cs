using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using ScriptableObjects.Inventory.Scripts;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject dayStartPanel;
    [SerializeField] private GameObject dayEndPanel;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private DayTextUI dayText;

    [Header("Day Counter")]
    [SerializeField] private IntVariable dayCount;
    [Header("Debug")]
    [SerializeField] private bool debugMode = false;
    [Header("Player Inventory")]
    [SerializeField] private InventoryObject playerInventory;

    [SerializeField] private ScriptableObject[] dataToReset;
    [Space(20)]
    [Header("Events")]
    public UnityEvent OnDayEnd;
    public UnityEvent OnNextDay;
    public UnityEvent OnWeekEnd;
    public UnityEvent OnGamePaused;
    public UnityEvent OnGameUnpaused;

    private bool gameHardPaused = true;
    
    private void Awake()
    {
        if (debugMode)
        {
            return;
        }
        ShowDayStartScreen();
        PauseGame();
    }

    public void StartDay()
    {
        AudioManager.PlaySound("GameMusic");
        HideDayStartScreen();
        UnpauseGame();
        gameHardPaused = false;
    }

    public void EndDay()
    {
        AudioManager.StopSound("GameMusic");
        PauseGame();
        gameHardPaused = true;
        OnDayEnd?.Invoke();
        
        if (CheckIfWin())
        {
            ShowWinScreen();
            return;
        }
        
        if (dayCount.Value >= 5)
        {
            OnWeekEnd?.Invoke();
            ShowLoseScreen();
            return;
        }

        ShowEndDayScreen();
    }

    public void NextDay()
    {
        dayCount.Increment();
        
        ResetDailyData();
        
        OnNextDay?.Invoke();
        SceneManager.LoadScene("MAIN");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TogglePauseMenu()
    {
        if (gameHardPaused)
        {
            return;
        }

        if (pauseMenu.pauseMenuActive)
        {
            pauseMenu.HidePauseMenu();
            UnpauseGame();
            return;
        }
        
        pauseMenu.ShowPauseMenu();
        PauseGame();
    }
    
    private void PauseGame()
    {
        OnGamePaused?.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    
    private void UnpauseGame()
    {
        OnGameUnpaused?.Invoke();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    private void ShowEndDayScreen()
    {
        dayText.SetDayText($"Day {dayCount.Value} finished");
        dayText.gameObject.SetActive(true);
        dayEndPanel.SetActive(true);
    }

    private void HideEndDayScreen()
    {
        dayText.gameObject.SetActive(false);
        dayEndPanel.SetActive(false);
    }

    private void ShowDayStartScreen()
    {
        dayText.SetDayText($"Day {dayCount.Value}");
        dayText.gameObject.SetActive(true);
        dayStartPanel.SetActive(true);
    }

    private void HideDayStartScreen()
    {
        dayText.gameObject.SetActive(false);
        dayStartPanel.SetActive(false);
    }

    private void ResetDailyData()
    {
        foreach (ScriptableObject data in dataToReset)
        {
            IResettable dataInterface = data as IResettable;
            dataInterface?.Reset();
        }
    }

    private void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }

    private bool CheckIfWin()
    {
        return playerInventory.Container.Count >= 4;
    }
}
