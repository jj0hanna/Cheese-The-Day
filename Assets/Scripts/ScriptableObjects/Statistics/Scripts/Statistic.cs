using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Statistic : ScriptableObject
{
    [SerializeField] private string statName;
    [SerializeField] protected FormatAs format;

    public string StatName => statName;
    
    public enum FormatAs
    {
        Simple,
        Money,
        Time
    }

    public virtual string GetFormattedStat()
    {
        return "";
    }
    
}
