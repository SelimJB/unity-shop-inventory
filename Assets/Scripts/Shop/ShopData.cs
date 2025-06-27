using UnityEngine;

namespace MyGame.Shop
{
	[CreateAssetMenu(fileName = "NewShop", menuName = "ScriptableObjects/Shop")]
	public class ShopData : ScriptableObject
	{
		[SerializeField] private ShopItem[] items;

		public ShopItem[] Items => items;
	}
}