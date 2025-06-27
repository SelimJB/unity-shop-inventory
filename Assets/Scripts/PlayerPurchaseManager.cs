using System;
using MyGame.Inventory;
using MyGame.Shop;
using Scenes;
using UnityEngine;

namespace MyGame.Core
{
	public class PlayerPurchaseManager : MonoBehaviour
	{
		[SerializeField] private float money = 10000f;
		[SerializeField] private InventoryData inventoryItems;
		[SerializeField] private ShopMenu shopMenu;

		public float Money => money;
		public event Action<float> OnBuyItem;
		public event Action OnPurchaseFailed;

		private void Start()
		{
			shopMenu.AddListenersToShopItems(HandlePurchaseRequest);
		}

		private void HandlePurchaseRequest(ShopItem shopItem)
		{
			if (money < shopItem.Price)
			{
				OnPurchaseFailed?.Invoke();
				return;
			}

			money -= shopItem.Price;
			inventoryItems.AddItem(shopItem.ItemData, 1);
			OnBuyItem?.Invoke(shopItem.Price);
		}
	}
}