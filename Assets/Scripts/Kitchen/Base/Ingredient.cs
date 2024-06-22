using UnityEngine;

namespace Kitchen.Base
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Kitchen/Ingredient")]
    public class Ingredient : Item
    {
         [Header("Ingredient Settings")]
         private bool isCooked = false;

         public bool IsCooked => isCooked;
    }
}
