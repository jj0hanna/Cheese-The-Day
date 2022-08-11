using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Upgrade", menuName = "Upgrades/Upgrade")]
public class Upgrade : ScriptableObject
{
    [Serializable]
    public struct UpgradeStructure
    {
        public int newLevelValue;
        public int cost;
    } 

    [SerializeField] private UpgradeStructure[] upgrades;
    [SerializeField] private string upgradeName;
    private int _currentUpgradeLevel;
    private int _maxUpgradeLevel;
    private bool _completed = false;

    public string UpgradeName => upgradeName;
    public int CurrentUpgradeLevel => _currentUpgradeLevel;
    public int MaxUpgradeLevel => _maxUpgradeLevel;
    public bool Completed => _completed;

    public int GetUpgradeCost()
    {
        return upgrades[_currentUpgradeLevel].cost;
    }
    
    private void OnEnable()
    {
        _currentUpgradeLevel = 0;
        _completed = false;
        _maxUpgradeLevel = upgrades.Length;
    }

    public int GetCurrentLevelValue()
    {
        if (_currentUpgradeLevel - 1 < 0)
        {
            return 0;
        }

        return upgrades[_currentUpgradeLevel - 1].newLevelValue;
    }

    public void IncreaseUpgradeLevel()
    {
        _currentUpgradeLevel++;
        if (_currentUpgradeLevel >= _maxUpgradeLevel)
        {
            _completed = true;
        }
    }
}
