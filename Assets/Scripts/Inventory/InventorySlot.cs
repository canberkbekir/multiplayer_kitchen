using Kitchen.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [Header("Dependencies")] [SerializeField]
        private Image icon;

        [SerializeField] public int slotIndex;
        public Item Item { get; private set; }


        public void AddItem(Item item)
        {
            Item = item;
            UpdateUI();
        }

        public void RemoveItem()
        {
            Item = null;
            UpdateUI();
        }

        public void UpdateUI()
        {
            icon.enabled = Item != null;
            icon.sprite = Item?.Icon;
        }
    }
}
