using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.Shop
{
	public class ShopItemView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI itemNameText;
		[SerializeField] private TextMeshProUGUI itemPriceText;
		[SerializeField] private TextMeshProUGUI itemDescriptionText;
		[SerializeField] private Image itemIcon;
		[SerializeField] private Button useButton;

		public event Action<ShopItem> OnUseButtonClicked;

		private ShopItem item;

		public void Initialize(ShopItem shopItem)
		{
			item = shopItem;
			itemNameText.text = item.ItemData.Name;
			itemPriceText.text = item.Price.ToString("F0", CultureInfo.InvariantCulture) + " $";
			itemDescriptionText.text = item.ItemData.Description;
			itemIcon.sprite = item.ItemData.Icon;
			useButton.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			OnUseButtonClicked?.Invoke(item);
		}

		private void OnDestroy()
		{
			useButton.onClick.RemoveAllListeners();
		}
	}
}