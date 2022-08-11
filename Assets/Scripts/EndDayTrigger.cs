using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndDayTrigger : MonoBehaviour
{
    // TODO rework these placeholders for giving player work money.
    [SerializeField] private IntVariable workMoney;
    [SerializeField] private IntVariable totalMoney;
    [SerializeField] private int moneyFromWork = 50;
    
    public UnityEvent OnEndDayTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // these are placeholders
            workMoney.AddValue(moneyFromWork);
            totalMoney.AddValue(moneyFromWork);
            OnEndDayTriggered?.Invoke();
        }
    }
}
