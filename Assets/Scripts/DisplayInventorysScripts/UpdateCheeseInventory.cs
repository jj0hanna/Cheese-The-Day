using ScriptableObjects.Inventory.Scripts;
using ScriptableObjects.Items.Scripts;
using UnityEngine;

namespace DisplayInventorysScripts
{
    public class UpdateCheeseInventory : MonoBehaviour
    {
        public InventoryObject inventory;

        [SerializeField] private GameObject[] slots;
        [SerializeField] private GameObject[] cheesePrefabs;

        private void Awake()
        {
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            if (inventory.Contains(ItemType.ParmigianoReggianoCheese))
            {
                Instantiate(cheesePrefabs[0], slots[0].transform);
            }

            if (inventory.Contains(ItemType.CamembertCheese))
            {
                Instantiate(cheesePrefabs[1], slots[1].transform);
            }

            if (inventory.Contains(ItemType.BleudeGexCheese))
            {
                Instantiate(cheesePrefabs[2], slots[2].transform);
            }

            if (inventory.Contains(ItemType.MozzarellaCheese))
            {
                Instantiate(cheesePrefabs[3], slots[3].transform);
            }
        }
    }
}
