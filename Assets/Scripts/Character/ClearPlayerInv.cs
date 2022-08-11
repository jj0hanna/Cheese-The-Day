using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Inventory.Scripts;
using ScriptableObjects.Items.Scripts;
using UnityEngine;

public class ClearPlayerInv : MonoBehaviour
{
    public InventoryObject playerCheeseInventory;

    private void OnApplicationQuit()
    {
        playerCheeseInventory.Container.Clear();
    }
}