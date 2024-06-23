using System;
using UnityEngine;

namespace Kitchen.Base
{
    public class InteractableIngredient : MonoBehaviour,IInteractable
    {
        [SerializeField] private Inventory.Inventory inventory;
        public Ingredient ingredient;
        public string InteractText { get; } = "Pick up";

        private void Awake()
        {
            inventory = FindObjectOfType<Inventory.Inventory>();
        }
        public void Interact()
        {
            if (ingredient == null) return;
            if (inventory.AddItem(ingredient))
            {
                Destroy(gameObject);
            }

        }
    }
}
