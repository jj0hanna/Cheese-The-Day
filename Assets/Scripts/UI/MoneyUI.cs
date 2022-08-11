using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private IntObservable moneyTotal;

    private TextMeshProUGUI moneyText;

    private void Awake()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyTotal.OnValueChanged += UpdateMoneyText;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = $"${moneyTotal.Value}";
    }
}
