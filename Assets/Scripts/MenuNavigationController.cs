using UnityEngine;
using UnityEngine.UI;

namespace MyGame.Item
{
	// TODO: Split controller logic and visual state management into separate components
	public class MenuNavigationController : MonoBehaviour
	{
		[SerializeField] private Button inventoryButton;
		[SerializeField] private Button shopButton;
		[SerializeField] private CanvasGroup inventoryMenu;
		[SerializeField] private CanvasGroup shopMenu;

		private Color selectedColor;
		private Color normalColor;

		private void Start()
		{
			inventoryButton.onClick.AddListener(OpenInventory);
			shopButton.onClick.AddListener(OpenShop);
			shopButton.Select();
			selectedColor = shopButton.colors.selectedColor;
			normalColor = shopButton.colors.normalColor;
		}

		private void OnDestroy()
		{
			inventoryButton.onClick.RemoveListener(OpenInventory);
			shopButton.onClick.RemoveListener(OpenShop);
		}

		private void OpenInventory()
		{
			ShowMenu(inventoryMenu);
			HideMenu(shopMenu);
		}

		private void OpenShop()
		{
			ShowMenu(shopMenu);
			HideMenu(inventoryMenu);
		}

		private void ShowMenu(CanvasGroup menu)
		{
			SetMenuVisibility(menu, true);

			SetButtonSelected(inventoryButton, menu == inventoryMenu);
			SetButtonSelected(shopButton, menu == shopMenu);
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