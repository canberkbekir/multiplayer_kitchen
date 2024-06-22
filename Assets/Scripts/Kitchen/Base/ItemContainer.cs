using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kitchen.Base
{
    [CreateAssetMenu(fileName = "ItemContainer", menuName = "Kitchen/ItemContainer")]
    public class ItemContainer : ScriptableObject
    {
        [SerializeField]
        public List<Item> items = new List<Item>();
    }
}
