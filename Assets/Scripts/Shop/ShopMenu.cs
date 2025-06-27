using System.Collections.Generic;
using MyGame.Shop;
using UnityEngine;

namespace Scenes
{
	public class ShopMenu : MonoBehaviour
	{
		[SerializeField] private ShopData shopData;
		[SerializeField] private ShopItemView shopItemPrefab;
		[SerializeField] private Transform itemContainer;

		private readonly List<ShopItemView> itemViews = new();

		private void Awake()
		{
			InitializeShopItems();
		}

		private void InitializeShopItems()
		{
			itemViews.Clear();

			foreach (Transform child in itemContainer)
			{
				Destroy(child.gameObject);
			}

			foreach (var shopItem in shopData.Items)
			{
				if (shopItem == null)
				{
					Debug.LogWarning("Shop item is null, skipping.");
					continue;
				}

				var itemView = Instantiate(shopItemPrefab, itemContainer);
				itemView.Initialize(shopItem);
				itemViews.Add(itemView);
			}
		}
		
		public void AddListenersToShopItems(System.Action<ShopItem> onUseButtonClicked)
		{
			foreach (var itemView in itemViews)
			{
				itemView.OnUseButtonClicked += onUseButtonClicked;
			}
		}
	}
}