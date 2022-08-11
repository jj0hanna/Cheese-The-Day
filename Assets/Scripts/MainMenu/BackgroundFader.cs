using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFader : MonoBehaviour
{
    [SerializeField] private GameObject[] elementsToHide;

    public void ShowBackgrounBlur()
    {
        gameObject.SetActive(true);
        HideElements();
    }

    public void HideBackgroundBlur()
    {
        gameObject.SetActive(false);
        ShowElements();
    }

    private void HideElements()
    {
        foreach (GameObject gameObject in elementsToHide)
        {
            gameObject.SetActive(false);
        }
    }

    private void ShowElements()
    {
        foreach (GameObject gameObject in elementsToHide)
        {
            gameObject.SetActive(true);
        }
    }
}
