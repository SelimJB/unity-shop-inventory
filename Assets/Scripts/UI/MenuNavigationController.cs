using MyGame.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
	// TODO: Split controller logic and visual state management into separate components
	public class MenuNavigationController : MonoBehaviour
	{
		[SerializeField] private Button inventoryButton;
		[SerializeField] private Button shopButton;
		[SerializeField] private CanvasGroup inventoryCanvasGroup;
		[SerializeField] private CanvasGroup shopCanvasGroup;
		[SerializeField] private InventoryMenu inventoryMenu;

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
			ShowMenu(inventoryCanvasGroup);
			HideMenu(shopCanvasGroup);
			inventoryMenu.RefreshItems();
		}

		private void OpenShop()
		{
			ShowMenu(shopCanvasGroup);
			HideMenu(inventoryCanvasGroup);
		}

		// TODO: Create MenuView class to handle visual state management
		private void ShowMenu(CanvasGroup menu)
		{
			SetMenuVisibility(menu, true);

			SetButtonSelected(inventoryButton, menu == inventoryCanvasGroup);
			SetButtonSelected(shopButton, menu == shopCanvasGroup);
		}

		private void HideMenu(CanvasGroup menu)
		{
			SetMenuVisibility(menu, false);
		}

		private void SetButtonSelected(Button button, bool selected)
		{
			var colors = button.colors;
			colors.normalColor = selected ? selectedColor : normalColor;
			button.colors = colors;
		}

		private void SetMenuVisibility(CanvasGroup menu, bool visible)
		{
			menu.alpha = visible ? 1f : 0f;
			menu.interactable = visible;
			menu.blocksRaycasts = visible;
		}
	}
}