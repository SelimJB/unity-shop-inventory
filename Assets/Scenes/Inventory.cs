using UnityEngine;
using MyGame.Item;

namespace MyGame.Inventory
{
	[CreateAssetMenu(fileName = "NewInventory", menuName = "ScriptableObjects/Inventory")]
	public class Inventory : ScriptableObject
	{
		[SerializeField] private InventoryItem[] items;

		public InventoryItem[] Items { get => items; set => items = value; }
	}

	[System.Serializable]
	public class InventoryItem
	{
		private GameItem item;
		private int quantity;

		public GameItem Item => item;
		public int Quantity => quantity;
	}
}