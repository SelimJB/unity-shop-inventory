using MyGame.Item;
using UnityEngine;

namespace MyGame.Shop
{
	[CreateAssetMenu(fileName = "NewShop", menuName = "ScriptableObjects/Shop")]
	public class Shop : ScriptableObject
	{
		[SerializeField] private ShopItem[] items;

		public ShopItem[] Items => Items;
	}

	[System.Serializable]
	public class ShopItem
	{
		[SerializeField] private GameItem item;
		[SerializeField] private float price;

		public GameItem Item => item;
		public float Price => price;
	}
}