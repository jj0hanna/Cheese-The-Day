using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResettable
{
    void Reset();
}

[CreateAssetMenu(fileName = "new IntVariable", menuName = "Variables/IntVariable")]
public class IntVariable : ScriptableObject, IResettable
{
    [SerializeField] private int _defaultValue;

    private int _value;
    public int Value => _value;

    public void SetValue(int value)
    {
        _value = value;
    }

    public virtual void AddValue(int value)
    {
        _value += value; 
    }

    public virtual void SubtractValue(int value)
    {
        _value -= value;
    }
    
    public void Increment()
    {
        _value++;
    }

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        _value = _defaultValue;
    }
}
