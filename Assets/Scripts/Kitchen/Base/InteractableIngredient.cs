using System;
using UnityEngine;

namespace Kitchen.Base
{
    public class InteractableIngredient : MonoBehaviour,IInteractable
    {
        public Ingredient ingredient;
        public string InteractText { get; } = "Pick up";

        public void Interact()
        {
            if (ingredient == null) return;
            Debug.Log("Picked up " + ingredient.ItemName);
            Destroy(gameObject);
        }
    }
}
