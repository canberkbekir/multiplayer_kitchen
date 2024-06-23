using System;
using JetBrains.Annotations;
using Kitchen.Base;
using Mirror;
using UnityEngine;

namespace Inventory
{
    public class Inventory : NetworkBehaviour
    {
        [field: Header("Dependencies")]
        [SerializeField] public int currentSlots { get; private set; } = 0;
        [SerializeField] public Item[] items { get; private set; }

        [field: Header("Settings")]
        [SerializeField] public int maxSlots { get; private set; } = 1;

        private void Start()
        {
            items = new Item[maxSlots];
        }

        private void Update()
        {
            if(!isOwned) {return;}
        }

        public event Action OnInventoryChanged;

        public bool AddItem(Item item)
        {
            // Check if all slots are full
            if (currentSlots >= maxSlots) return false;

            // Check if the current slot is not null
            if (items[currentSlots] != null)
            {
                // Try to find an empty slot
                for (int i = 0; i < maxSlots; i++)
                {
                    if (items[i] != null) continue;
                    items[i] = item;
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
            else
            {
                // If the current slot is null, add the item there
                items[currentSlots] = item;
                OnInventoryChanged?.Invoke();
                return true;
            }

            // If no empty slot was found, return false
            return false;
        }

        [CanBeNull]
        public Item RemoveItem()
        {
            var tempItem = items[currentSlots];
            items[currentSlots] = null;
            OnInventoryChanged?.Invoke();
            return tempItem;

        }

        [CanBeNull]
        public Item GetItem() => items[currentSlots];

        public void NextSlot()
        {
            if (currentSlots < maxSlots - 1)
            {
                currentSlots++;
            }
            else
            {
                currentSlots = 0;
            }
            OnInventoryChanged?.Invoke();
        }

        public void PreviousSlot()
        {
            if (currentSlots > 0)
            {
                currentSlots--;
            }
            else
            {
                currentSlots = maxSlots - 1;
            }
            OnInventoryChanged?.Invoke();
        }

        public void ClearInventory()
        {
            for (int i = 0; i < maxSlots; i++)
            {
                items[i] = null;
            }
            OnInventoryChanged?.Invoke();
        }

        public void SetSlot(int slotIndex)
        {
            currentSlots = slotIndex;
            OnInventoryChanged?.Invoke();
        }

    }
}
