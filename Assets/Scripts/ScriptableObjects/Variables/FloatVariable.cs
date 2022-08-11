using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new FloatVariable", menuName = "Variables/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _defaultValue;

    private float _value;
    
    public float Value => _value;

    public void SetValue(float value)
    {
        _value = value;
    }
    
    public void AddValue(float value)
    {
        _value += value;
    }

    private void OnEnable()
    {
        _value = _defaultValue;
    }
}
