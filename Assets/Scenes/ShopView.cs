using MyGame.Shop;
using UnityEngine;

namespace Scenes
{
	public class ShopView : MonoBehaviour
	{
		[SerializeField] private Shop shop;
		[SerializeField] private ShopItemView shopItemPrefab;
		[SerializeField] private Transform itemContainer;

		private void Start()
		{
			InitializeShopItems();
		}

		private void InitializeShopItems()
		{
			foreach (Transform child in itemContainer)
			{
				Destroy(child.gameObject);
			}

			foreach (var shopItem in shop.Items)
			{
				if (shopItem == null)
				{
					Debug.LogWarning("Shop item is null, skipping.");
					continue;
				}

				var itemView = Instantiate(shopItemPrefab, itemContainer);
				itemView.Initialize(shopItem);
			}
		}
	}
}