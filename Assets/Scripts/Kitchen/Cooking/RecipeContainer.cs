using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Cooking
{
    [CreateAssetMenu(fileName = "RecipeContainer", menuName = "Kitchen/RecipeContainer")]
    public class RecipeContainer : ScriptableObject
    {
        [SerializeField]
        public List<Recipe> recipes = new List<Recipe>();
    }
}
