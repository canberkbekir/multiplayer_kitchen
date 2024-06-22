using Kitchen.Base;
using UnityEngine;

namespace Kitchen.Cooking
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Kitchen/Recipe")]
    public class Recipe : ScriptableObject
    {
        [Header("Recipe Settings")]
        [SerializeField]  private string _recipeName;
        [SerializeField] private int _price;
        [SerializeField] private int _id;
        [SerializeField] private Ingredient[] _ingredients;
        [SerializeField] private Ingredient _result;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _timeToMake;

        public string RecipeName => _recipeName;
        public int Price => _price;
        public int Id => _id;
        public Ingredient[] Ingredients => _ingredients;
        public Ingredient Result => _result;
        public Sprite Icon => _icon;
        public float TimeToMake => _timeToMake;
    }
}
