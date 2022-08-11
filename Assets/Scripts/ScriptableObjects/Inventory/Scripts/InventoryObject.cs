using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Items.Scripts;
using UnityEngine;

namespace ScriptableObjects.Inventory.Scripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        public List<InventorySlot> Container = new List<InventorySlot>();

        public void AddItem(ItemObject Item, int Amount)
        {
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].item == Item) // if item already exist in inventory add one more
                {
                    Container[i].AddAmount(Amount);
                    return;
                }
            }
            Container.Add(new InventorySlot(Item, Amount));
        }

        public void RemoveItem(ItemObject item, int Amount)
        {
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].item == item)
                {
                    Container[i].RemoveAmount(Amount);
                    break;
                }
            }
        }
        public bool Contains(ItemType itemType)
        {
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].item.type == itemType && Container[i].amount > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
    [System.Serializable]
    public class InventorySlot
    {
        public ItemObject item;
        public int amount;

        public InventorySlot(ItemObject Item, int Amount)
        {
            item = Item;
            amount = Amount;
        }
        public void AddAmount(int value)
        {
            amount += value;
        }
        public void RemoveAmount(int value)
        {
            amount -= value;
        }
    }
}