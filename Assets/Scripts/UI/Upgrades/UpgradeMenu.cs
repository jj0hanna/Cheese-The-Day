using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private UpgradeEntry[] upgrades;
    
    private void Awake()
    {
        upgrades = GetComponentsInChildren<UpgradeEntry>();

        foreach (UpgradeEntry entry in upgrades)
        {
            entry.upgradeDelegate = UpdateAllChildren;
        }
    }

    private void UpdateAllChildren()
    {
        foreach (UpgradeEntry entry in upgrades)
        {
            entry.UpdateInformation();
        }
    }
}
