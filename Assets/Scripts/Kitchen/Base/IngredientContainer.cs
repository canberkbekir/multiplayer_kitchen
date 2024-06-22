using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Base
{
    [CreateAssetMenu(fileName = "IngredientContainer", menuName = "Kitchen/IngredientContainer")]
    public class IngredientContainer : ScriptableObject
    {
        [SerializeField]
        public List<Ingredient> Ingredients = new List<Ingredient>();

    }
}
