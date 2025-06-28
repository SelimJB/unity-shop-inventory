using MyGame.Inventory;
using MyGame.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
	public class MenuNavigationController : MonoBehaviour
	{
		[SerializeField] private Button inventoryButton;
		[SerializeField] private Button shopButton;
		[SerializeField] private InventoryMenu inventoryMenu;
		[SerializeField] private ShopMenu shopMenu;

		private Color selectedColor;
		private Color normalColor;

		private void Start()
		{
			inventoryButton.onClick.AddListener(OpenInventory);
			shopButton.onClick.AddListener(OpenShop);

			selectedColor = shopButton.colors.selectedColor;
			normalColor = shopButton.colors.normalColor;
			OpenShop();
		}

		private void OnDestroy()
		{
			inventoryButton.onClick.RemoveListener(OpenInventory);
			shopButton.onClick.RemoveListener(OpenShop);
		}

		private void OpenInventory()
		{
			inventoryMenu.RefreshItems();
			inventoryMenu.Toggle(true);
			shopMenu.Toggle(false);
			SetButtonSelected(inventoryButton, true);
			SetButtonSelected(shopButton, false);
		}

		private void OpenShop()
		{
			shopMenu.Toggle(true);
			inventoryMenu.Toggle(false);
			SetButtonSelected(inventoryButton, false);
			SetButtonSelected(shopButton, true);
		}

		private void SetButtonSelected(Button button, bool selected)
		{
			var colors = button.colors;
			colors.normalColor = selected ? selectedColor : normalColor;
			button.colors = colors;
		}
	}
}