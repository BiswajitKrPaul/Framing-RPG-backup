using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory {
    public class InventorySlotItem : MonoBehaviour {
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshPro slotItemCount;


        public void SetItem(Sprite itemSprite, int count) {
            itemImage.sprite = itemSprite;
            slotItemCount.text = count.ToString();
        }

        public void UnSetItem() {
            itemImage.sprite = null;
            slotItemCount.text = "";
        }
    }
}