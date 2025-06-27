using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.Inventory
{
	public class InventoryItemView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI itemNameText;
		[SerializeField] private TextMeshProUGUI itemDescriptionText;
		[SerializeField] private TextMeshProUGUI itemQuantityText;
		[SerializeField] private Image itemIcon;

		private InventoryItem item;

		public void Initialize(InventoryItem inventoryItem)
		{
			item = inventoryItem;
			itemNameText.text = item.ItemData.Name;
			itemDescriptionText.text = item.ItemData.Description;
			itemQuantityText.text = $"x{item.Quantity}";
			itemIcon.sprite = item.ItemData.Icon;
		}
	}
}