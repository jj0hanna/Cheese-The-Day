using Animation;
using Audio;
using DisplayInventorysScripts;
using ScriptableObjects.Inventory.Scripts;
using ScriptableObjects.Items.Scripts;
using UI;
using UnityEngine;

namespace StoresLogicScripts
{
    public class ObjectStore : MonoBehaviour, Interactable
    {
        [SerializeField] private InventoryObject ObjectplayerInventory;
        [SerializeField] private InventoryObject ObjectstoreInventory;
        [SerializeField] private ObjectInventoryAnimation ObjectinventoryAnimation;
        [SerializeField] private UpdateObjectInventory updateObjectInventoryDisplay;

        [SerializeField] private IntObservable moneyTotal;
        [SerializeField] private int Cost = 5;
        [SerializeField] private BuyTextUI buyText;

        private ItemObject Object;

        private void Start()
        {
            buyText.gameObject.SetActive(false);
        }

        public void Interact()
        {
            for (int i = 0; i < ObjectstoreInventory.Container.Count; i++)
            {
                Object = ObjectstoreInventory.Container[i].item;

                if (!ObjectplayerInventory.Contains(Object.type))
                {
                    if (moneyTotal.Value < Cost)
                    {
                        buyText.gameObject.SetActive(false);
                        buyText.SetbuyCheeseText(
                            $"You dont have enough money to buy this one, you currently have - ${moneyTotal.Value}");
                    }
                    else
                    {
                        AudioManager.PlaySound("CheeseSound");
                        ObjectplayerInventory.AddItem(Object, 1);
                        moneyTotal.SubtractValue(Cost);
                        StartCoroutine(ObjectinventoryAnimation.MoveInventory());
                        updateObjectInventoryDisplay.UpdateDisplay();
                        buyText.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            for (int i = 0; i < ObjectstoreInventory.Container.Count; i++)
            {
                Object = ObjectstoreInventory.Container[i].item;
                if (!ObjectplayerInventory.Contains(Object.type))
                {
                    buyText.SetbuyCheeseText($"Press E to buy - ${Cost}");
                    AudioManager.PlaySound("InteractSound");
                    buyText.gameObject.SetActive(true);
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            buyText.gameObject.SetActive(false);
        }
    }
}