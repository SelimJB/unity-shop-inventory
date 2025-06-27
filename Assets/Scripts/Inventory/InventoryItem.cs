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
		public int Quantity => quantity;
	}
}