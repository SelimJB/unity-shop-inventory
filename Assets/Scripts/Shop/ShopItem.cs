using MyGame.Item;
using UnityEngine;

namespace MyGame.Shop
{
	[System.Serializable]
	public class ShopItem
	{
		[SerializeField] private ItemData itemData;
		[SerializeField] private float price;

		public ItemData ItemData => itemData;
		public float Price => price;
	}
}