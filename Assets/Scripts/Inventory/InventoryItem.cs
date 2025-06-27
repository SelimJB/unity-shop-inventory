using MyGame.Item;
using UnityEngine;

namespace MyGame.Inventory
{
	[System.Serializable]
	public class InventoryItem
	{
		[SerializeField] private ItemData itemData;
		[SerializeField] private int quantity;
		
		public ItemData ItemData => itemData;
		public int Quantity { get => quantity; set => quantity = value; }
		
		public InventoryItem(ItemData itemData, int quantity = 1)
		{
			this.itemData = itemData;
			this.quantity = quantity;
		}
	}
}