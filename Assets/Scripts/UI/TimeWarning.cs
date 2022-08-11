using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeWarning : MonoBehaviour
{
    [SerializeField] private float displayTime = 5f;
    
    private TextMeshProUGUI warningText;
    private Transform transformCache;

    private bool shouldShowWarning = false;
    
    private void Awake()
    {
        warningText = GetComponent<TextMeshProUGUI>();
        transformCache = gameObject.transform;
    }

    private void OnEnable()
    {
        if (!shouldShowWarning)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        float scaler = Mathf.PingPong(Time.time * 0.3f, .3f);
        scaler += 1f;
        
        transformCache.localScale = new Vector3(scaler, scaler, scaler);
        
        displayTime -= Time.deltaTime;
        if (displayTime <= 0f)
        {
            HideWarning();
        }
    }

    public void ShowWarning()
    {
        shouldShowWarning = true;
        gameObject.SetActive(true);
    }

    public void HideWarning()
    {
        shouldShowWarning = false;
        gameObject.SetActive(false);
    }
}
