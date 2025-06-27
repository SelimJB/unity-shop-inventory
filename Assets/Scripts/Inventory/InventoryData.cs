using UnityEngine;

namespace MyGame.Inventory
{
	[CreateAssetMenu(fileName = "NewInventory", menuName = "ScriptableObjects/Inventory")]
	public class InventoryData : ScriptableObject
	{
		[SerializeField] private InventoryItem[] items;

		public InventoryItem[] Items { get => items; set => items = value; }
	}
}