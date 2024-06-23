using System;
using UnityEngine;

namespace Kitchen.Base
{
    [CreateAssetMenu(fileName = "Item", menuName = "Kitchen/Item")]
    public class Item : ScriptableObject
    {
        [Header("Item Settings")]
        [SerializeField] private string _itemName;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;
        [SerializeField] private int _id;
        [SerializeField] private GameObject _prefab;

        public string ItemName => _itemName;
        public Sprite Icon => _icon;
        public int Price => _price;
        public int Id => _id;
        public GameObject Prefab => _prefab;
    }
}
