using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject[] canvasGroups;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private TextMeshProUGUI nextButtonText;

    private int currentCanvasIndex;
    
    public UnityEvent OnFinishedClicked;

    public void NextPanel()
    {
        if (currentCanvasIndex + 1 >= canvasGroups.Length)
        {
            OnFinishedClicked?.Invoke();
            return;
        }
        
        HideElement(currentCanvasIndex);
        currentCanvasIndex++;
        
        if (currentCanvasIndex == canvasGroups.Length - 1)
        {
            nextButtonText.text = "Next Day";
        }
        previousButton.SetActive(true);
        ShowElement(currentCanvasIndex);
    }

    public void PreviousPanel()
    {
        HideElement(currentCanvasIndex);
        currentCanvasIndex--;
        if (currentCanvasIndex == 0)
        {
            previousButton.SetActive(false);
        }
        ShowElement(currentCanvasIndex);
        nextButtonText.text = "Next";
    }

    private void ShowElement(int index)
    {
        canvasGroups[index].SetActive(true);
    }

    private void HideElement(int index)
    {
        canvasGroups[index].SetActive(false);
    }
    
}
