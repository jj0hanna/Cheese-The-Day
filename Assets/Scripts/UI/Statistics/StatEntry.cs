using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statNameText;
    [SerializeField] private TextMeshProUGUI statValueText;
    [SerializeField] private Statistic statObject;
    
    private void Awake()
    {
        if (statObject != null)
        {
            SetStatName();
        }
    }

    public void Refresh()
    {
        SetStatValue();
    }

    private void SetStatValue()
    {
        statValueText.text = statObject.GetFormattedStat();
    }

    private void SetStatName()
    {
        statNameText.text = statObject.StatName + ":";
    }
}
