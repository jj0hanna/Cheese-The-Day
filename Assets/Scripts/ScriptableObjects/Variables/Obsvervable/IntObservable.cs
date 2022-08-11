using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new IntObservable", menuName = "Variables/Observable/IntObservable")]
public class IntObservable : IntVariable
{
    public event Action OnValueChanged;

    public override void AddValue(int value)
    {
        base.AddValue(value);
        OnValueChanged?.Invoke();
    }

    public override void SubtractValue(int value)
    {
        base.SubtractValue(value);
        OnValueChanged?.Invoke();
    }
}
