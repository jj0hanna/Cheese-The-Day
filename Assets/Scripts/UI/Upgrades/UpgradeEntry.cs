using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class UpgradeEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradeLevelText;
    [SerializeField] private TextMeshProUGUI upgradeButtonText;
    [SerializeField] private Button upgradeButton;

    [SerializeField] private Upgrade upgrade;
    [SerializeField] private IntObservable playerMoney;

    public delegate void UpgradeDelegate();
    public UpgradeDelegate upgradeDelegate;

    private void Awake()
    {
        if (upgrade != null)
        {
            upgradeNameText.text = upgrade.UpgradeName;
            UpdateInformation();
        }
    }

    public void Upgrade()
    {
        if (playerMoney.Value < upgrade.GetUpgradeCost())
        {
            return;
        }
        playerMoney.SubtractValue(upgrade.GetUpgradeCost());
        upgrade.IncreaseUpgradeLevel();
        upgradeDelegate.Invoke();
    }
    
    public void UpdateInformation()
    {
        SetUpgradeText();
        
        if (upgrade.Completed)
        {
            SetCompleted();
            return;
        }
        
        SetCostText();
        
        if (upgrade.GetUpgradeCost() > playerMoney.Value)
        {
            SetNoAffordVisual();
        }
    }

    private void SetCompleted()
    {
        upgradeButtonText.text = "COMPLETED";
        DisableButton();
    }

    private void SetUpgradeText()
    {
        upgradeLevelText.text = $"{upgrade.CurrentUpgradeLevel} / {upgrade.MaxUpgradeLevel}";
    }

    private void SetCostText()
    {
        upgradeButtonText.text = $"${upgrade.GetUpgradeCost()}";
    }

    private void SetNoAffordVisual()
    {
        ColorBlock newColorBlock = upgradeButton.colors;
        newColorBlock.disabledColor = Color.red;
        upgradeButton.colors = newColorBlock;
        DisableButton();
    }

    private void DisableButton()
    {
        upgradeButton.interactable = false;
    }
}
