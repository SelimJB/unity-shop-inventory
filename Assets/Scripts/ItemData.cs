using UnityEngine;

namespace MyGame.Item
{
	[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item")]
	public class GameItem : ScriptableObject // Todo: rename to GameItemData
	{
		[SerializeField] private string itemName;
		[SerializeField] private string itemDescription;
		[SerializeField] private Sprite itemIcon;

		public string Name => itemName;
		public string Description => itemDescription;
		public Sprite Icon => itemIcon;
	}
}