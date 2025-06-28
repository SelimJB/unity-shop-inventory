using MyGame.Core;
using TMPro;
using UnityEngine;

namespace MyGame.UI
{
	public class MoneyDisplayController : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI moneyText;
		[SerializeField] private PlayerPurchaseManager playerPurchaseManager;

		private void Start()
		{
			playerPurchaseManager.OnBuyItem += OnItemPurchased;
			UpdateMoneyText();
		}

		private void OnItemPurchased(float price)
		{
			UpdateMoneyText();
		}

		private void UpdateMoneyText()
		{
			moneyText.text = playerPurchaseManager.Money.ToString("F0", System.Globalization.CultureInfo.InvariantCulture) + " $";
		}

		private void OnDestroy()
		{
			playerPurchaseManager.OnBuyItem -= OnItemPurchased;
		}
	}
}