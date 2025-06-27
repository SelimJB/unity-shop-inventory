using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Inventory
{
	public class InventoryMenu : MonoBehaviour
	{
		[SerializeField] private InventoryData inventoryItems;
		[SerializeField] private InventoryItemView inventoryItemPrefab;
		[SerializeField] private Transform itemContainer;

		private readonly List<InventoryItemView> itemViews = new();

		private void Awake()
		{
			RefreshItems();
		}

		public void RefreshItems()
		{
			itemViews.Clear();

			foreach (Transform child in itemContainer)
			{
				Destroy(child.gameObject);
			}

			foreach (var item in inventoryItems.Items)
			{
				if (item == null)
				{
					Debug.LogWarning("Inventory item is null, skipping.");
					continue;
				}

				var itemView = Instantiate(inventoryItemPrefab, itemContainer);
				itemView.Initialize(item);
				itemViews.Add(itemView);
			}
		}

		public void AddListenersToInventoryItems(System.Action<InventoryItem> onUseButtonClicked)
		{
			foreach (var itemView in itemViews)
			{
				itemView.OnUseButtonClicked += onUseButtonClicked;
			}
		}
	}
}