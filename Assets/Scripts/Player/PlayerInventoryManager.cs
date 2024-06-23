using Input;
using UnityEngine;

namespace Player
{
    public class PlayerInventoryManager : MonoBehaviour
    {
        [SerializeField] private Inventory.Inventory inventory;
        [SerializeField] private Transform dropItemTransform;
        [SerializeField] private InputObject inputObject;

        private void Awake()
        {
            inventory = FindObjectOfType<Inventory.Inventory>();

            inputObject.DropEvent += OnDrop;
        }

        private void OnDrop()
        {
            if (!inventory.GetItem()) return;

            var item = inventory.RemoveItem();
            Instantiate(item.Prefab, dropItemTransform.position, Quaternion.identity);
        }
    }
}
