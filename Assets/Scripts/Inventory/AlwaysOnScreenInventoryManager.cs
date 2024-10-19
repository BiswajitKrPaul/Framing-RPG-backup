using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inventory {
    public class AlwaysOnScreenInventoryManager : MonoBehaviour {
        [SerializeField] private GameObject inventorySlot;

        [SerializeField] private int slotItemCount;
        private PlayerInputActions _playerInputActions;


        private void Awake() {
            AddInventorySlot();
        }


        private void AddInventorySlot() {
            for (var i = 0; i < slotItemCount; i++) {
                var newItemSlot = Instantiate(inventorySlot, transform);
                newItemSlot.transform.localPosition = Vector3.zero;
                newItemSlot.transform.localRotation = Quaternion.identity;
            }
        }
    }
}