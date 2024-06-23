using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private InventorySlot[] inventorySlots;
        [SerializeField] private GameObject inventorySlotPrefab;

        private void Awake()
        {
            inventory = FindObjectOfType<Inventory>();
            inventorySlots = new InventorySlot[inventory.maxSlots];
            for (var i = 0; i < inventory.maxSlots; i++)
            {
                GameObject slot = Instantiate(inventorySlotPrefab, transform);
                InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
                inventorySlot.slotIndex = i;
                inventorySlots[i] = inventorySlot;
            }

            inventory.OnInventoryChanged += UpdateUI;
        }


        private void UpdateUI()
        {
            for (var i = 0; i < inventory.maxSlots; i++)
            {
                if (inventorySlots[i])
                {
                    inventorySlots[i].AddItem(inventory.items[i]);
                }
            }
        }
    }
}
