using System;
using MyGame.Inventory;
using MyGame.Shop;
using Scenes;
using TMPro;
using UnityEngine;

namespace MyGame.Core
{
	public class PlayerPurchaseManager : MonoBehaviour
	{
		[SerializeField] private float money = 10000f;
		[SerializeField] private TextMeshProUGUI moneyText;
		[SerializeField] private InventoryData inventoryItems;
		[SerializeField] private ShopMenu shopMenu;

		public event Action<float> OnBuyItem;

		private void Start()
		{
			shopMenu.AddListenersToShopItems(HandlePurchaseRequest);
			UpdateMoneyText();
		}

		private void HandlePurchaseRequest(ShopItem shopItem)
		{
			if (money < shopItem.Price)
			{
				Debug.LogWarning($"Not enough money to purchase {shopItem.ItemData.Name}. Required: {shopItem.Price}, Available: {money}");
				return;
			}

			money -= shopItem.Price;
			UpdateMoneyText();
			inventoryItems.AddItem(shopItem.ItemData, 1);
			OnBuyItem?.Invoke(shopItem.Price);
		}

		private void UpdateMoneyText()
		{
			moneyText.text = money.ToString("F0", System.Globalization.CultureInfo.InvariantCulture) + " $";
		}
	}
}