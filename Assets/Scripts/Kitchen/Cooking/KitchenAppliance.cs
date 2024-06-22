using Kitchen.Base;
using UnityEngine;

namespace Kitchen.Cooking
{
    public enum KitchenApplianceStatus
    {
        Empty,
        Cooking,
        Done
    }

    public abstract class KitchenAppliance : MonoBehaviour
    {
        [Header("Appliance Status")]
        public KitchenApplianceStatus status = KitchenApplianceStatus.Empty;


        [Header("Appliance Settings")]
        public int maxIngredients;
        public string applianceName;

        [Header("Debug Settings")]
        public Ingredient[] currentIngredients;
        public Ingredient result;


        public abstract void Use(Ingredient[] ingredients);

        public abstract void AddIngredient(Ingredient ingredient);
    }
}
