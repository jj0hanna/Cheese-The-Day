using UnityEngine;

namespace ScriptableObjects.Items.Scripts
{
    public enum ItemType
    {
        ParmigianoReggianoCheese, 
        CamembertCheese,
        BleudeGexCheese,
        MozzarellaCheese,
        Coffee,
        Newspaper,
        Default,
    }

    public abstract class ItemObject : ScriptableObject
    {
        public GameObject prefab;
        public ItemType type;
        [TextArea(15, 20)] public string description;
    }
}