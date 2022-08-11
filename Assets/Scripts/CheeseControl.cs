using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using ScriptableObjects.Inventory.Scripts;
using ScriptableObjects.Obstacles.Scripts;
using UnityEngine;

public class CheeseControl : MonoBehaviour
{
    [SerializeField] private InventoryObject playerInventory;
    [SerializeField] private Transform winScreen;
    public void CheeseCheck()
    {
        if (playerInventory.Container.Count >= 4)
        {
            winScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            AudioManager.StopSound("MainMusic");
        }
    }
}
