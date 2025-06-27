using MyGame.Core;
using TMPro;
using UnityEngine;

namespace MyGame.UI
{
	public class CurrencyDisplayController : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI moneyText;
		[SerializeField] private PlayerPurchaseManager playerPurchaseManager;

		private void Start()
		{
			if (playerPurchaseManager != null)
			{
				playerPurchaseManager.OnBuyItem += OnItemPurchased;
				playerPurchaseManager.OnPurchaseFailed += OnPurchaseFailed;
			}

			UpdateMoneyText();
		}

		private void OnItemPurchased(float price)
		{
			UpdateMoneyText();
		}

		private void OnPurchaseFailed()
		{
			UpdateMoneyText();
		}

		private void UpdateMoneyText()
		{
			moneyText.text = playerPurchaseManager.Money.ToString("F0", System.Globalization.CultureInfo.InvariantCulture) + " $";
		}

		private void OnDestroy()
		{
			if (playerPurchaseManager != null)
			{
				playerPurchaseManager.OnBuyItem -= OnItemPurchased;
				playerPurchaseManager.OnPurchaseFailed -= OnPurchaseFailed;
			}
		}
	}
}