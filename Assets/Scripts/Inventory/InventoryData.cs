using System.Collections.Generic;
using System.Linq;
using MyGame.Item;
using UnityEngine;

namespace MyGame.Inventory
{
	[CreateAssetMenu(fileName = "NewInventory", menuName = "ScriptableObjects/Inventory")]
	public class InventoryData : ScriptableObject
	{
		[SerializeField] private List<InventoryItem> items = new();

		private readonly Dictionary<ItemData, InventoryItem> itemDictionary = new();
		public List<InventoryItem> Items => items;

		public void OnEnable()
		{
			RefreshDictionary();
		}

		public void RefreshDictionary()
		{
			itemDictionary.Clear();
			foreach (var item in items.Where(item => item.ItemData != null))
			{
				itemDictionary[item.ItemData] = item;
			}
		}

		public void AddItem(ItemData itemData, int quantity)
		{
			if (itemDictionary.TryGetValue(itemData, out InventoryItem inventoryItem))
			{
				inventoryItem.Quantity += quantity;
			}
			else
			{
				var newItem = new InventoryItem(itemData, quantity);
				items.Add(newItem);
				itemDictionary[itemData] = newItem;
			}
		}
	}
}