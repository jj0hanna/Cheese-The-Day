using Animation;
using Audio;
using DisplayInventorysScripts;
using ScriptableObjects.Inventory.Scripts;
using ScriptableObjects.Items.Scripts;
using UI;
using UnityEngine;

namespace StoresLogicScripts
{
    public class CheeseStore : MonoBehaviour, Interactable
    {
        [SerializeField] private InventoryObject playerInventory;
        [SerializeField] private InventoryObject storeInventory;
        [SerializeField] private CheeseInventoryAnimation inventoryAnimation;
        [SerializeField] private UpdateCheeseInventory updateCheeseInventoryDisplay;

        [SerializeField] private IntObservable moneyTotal;
        [SerializeField] private int cheeseCost = 5;
        [SerializeField] private BuyTextUI buyCheesetext;

        private ItemObject cheese;

        private void Start()
        {
            buyCheesetext.gameObject.SetActive(false);
        }

        public void Interact()
        {
            for (int i = 0; i < storeInventory.Container.Count; i++)
            {
                cheese = storeInventory.Container[i].item;

                if (!playerInventory.Contains(cheese.type)) // check if the player dont have that specific cheese in the inventory that the store have
                {
                    if (moneyTotal.Value < cheeseCost)
                    {
                        buyCheesetext.SetbuyCheeseText(
                            $"You dont have enough money to buy this cheese, you are missing ${cheeseCost - moneyTotal.Value}");
                    }
                    else
                    {
                        // if the player dont have that cheese, add the cheese to the inventory
                        AudioManager.PlaySound("CheeseSound");
                        playerInventory.AddItem(cheese, 1);
                        moneyTotal.SubtractValue(cheeseCost);
                        StartCoroutine(inventoryAnimation.MoveInventory());
                        updateCheeseInventoryDisplay.UpdateDisplay();
                        buyCheesetext.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            for (int i = 0; i < storeInventory.Container.Count; i++)
            {
                cheese = storeInventory.Container[i].item;
                if (!playerInventory.Contains(cheese.type))
                {
                    buyCheesetext.SetbuyCheeseText($"Press E to buy this cheese - ${cheeseCost}");
                    AudioManager.PlaySound("InteractSound");
                    buyCheesetext.gameObject.SetActive(true);
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            buyCheesetext.gameObject.SetActive(false);
        }
    }
}