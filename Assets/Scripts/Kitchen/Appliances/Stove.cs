using System.Linq;
using System.Threading.Tasks;
using Kitchen.Base;
using Kitchen.Cooking;
using UnityEngine;

namespace Kitchen.Appliances
{
    public class Stove : KitchenAppliance,IInteractable
    {
        public string InteractText { get; } = "Cook";
        private void Start()
        {
            applianceName = "Stove";
            maxIngredients = 1;
            currentIngredients = new Ingredient[maxIngredients];
        }

        public override async void Use(Ingredient[] ingredients)
        {
            // if (status == KitchenApplianceStatus.Cooking || currentIngredients.All(ingredient => !ingredient)) return;
            if (status == KitchenApplianceStatus.Cooking) return;

            if(status == KitchenApplianceStatus.Done)
            {
                GetIngredient();
                return;
            }

            if (status == KitchenApplianceStatus.Empty)
            {
               await Cook();
            }
        }

        public override void AddIngredient(Ingredient ingredient)
        {
            for (var i = 0; i < maxIngredients; i++)
            {
                if (currentIngredients[i] != null) continue;
                currentIngredients[i] = ingredient;
                break;
            }
        }



        public void Interact()
        {
            Use(currentIngredients);
        }

        private async Task Cook()
        {
            Debug.Log("Cooking started");
            status = KitchenApplianceStatus.Cooking;
            await Task.Delay(3000);
            status = KitchenApplianceStatus.Done;
            Debug.Log("Cooking done");
        }

        private void GetIngredient()
        {
            status = KitchenApplianceStatus.Empty;
        }
    }
}
