using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsPanelUI : MonoBehaviour
{
    private StatEntry[] children;
    
    private void Awake()
    {
        children = GetComponentsInChildren<StatEntry>();
    }

    private void OnEnable()
    {
        RefreshEntries();
    }

    private void RefreshEntries()
    {
        foreach (StatEntry entry in children)
        {
            entry.Refresh();
        }
    }
}
