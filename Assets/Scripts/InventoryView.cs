using UnityEngine;

namespace MyGame.Inventory
{
	public class InventoryView : MonoBehaviour
	{
		[SerializeField] private InventoryData inventoryItems;
		[SerializeField] private InventoryItemView inventoryItemPrefab;
		[SerializeField] private Transform itemContainer;

		private void Start()
		{
			InitializeInventoryItems();
		}

		private void InitializeInventoryItems()
		{
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
			}
		}
	}
}