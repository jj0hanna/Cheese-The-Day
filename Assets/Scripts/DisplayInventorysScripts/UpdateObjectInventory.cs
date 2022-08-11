using ScriptableObjects.Inventory.Scripts;
using UnityEngine;

namespace DisplayInventorysScripts
{
    public class UpdateObjectInventory : MonoBehaviour
    {
        public InventoryObject inventoryObjectinventory;

        [SerializeField] private GameObject[] slots;

        private void Awake()
        {
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            for (int i = 0; i < inventoryObjectinventory.Container.Count; i++)
            {
                GameObject prefab = inventoryObjectinventory.Container[i].item.prefab;
                Debug.Log(Instantiate(prefab, slots[i].transform));
            }
        }
    }
}