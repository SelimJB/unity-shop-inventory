using DG.Tweening;
using MyGame.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
	public class MoneyDisplayController : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI moneyText;
		[SerializeField] private PlayerPurchaseManager playerPurchaseManager;

		[Header("Visual Feedback")]
		[SerializeField] private Image overlayImage;
		[SerializeField] private float flashDuration = 0.2f;
		[SerializeField] private Color flashColor = new(1f, 0f, 0f, 0.4f);

		[Header("Animation Settings")]
		[SerializeField] private Ease fadeInEase = Ease.OutQuad;
		[SerializeField] private Ease fadeOutEase = Ease.InQuad;
		[SerializeField] private float shakeStrength = 1f;
		[SerializeField] private int shakeVibrato = 10;

		private Sequence currentFlashSequence;
		private Vector3 textInitialPosition;
		private Vector3 textInitialScale;

		private void Start()
		{
			if (playerPurchaseManager != null)
			{
				playerPurchaseManager.OnBuyItem += OnItemPurchased;
				playerPurchaseManager.OnPurchaseFailed += OnPurchaseFailed;
			}

			textInitialScale = moneyText.transform.localScale;
			textInitialPosition = moneyText.transform.localPosition;

			UpdateMoneyText();
		}

		private void OnItemPurchased(float price)
		{
			UpdateMoneyText();
		}

		private void OnPurchaseFailed()
		{
			UpdateMoneyText();
			PlayFailedPurchaseAnimation();
		}

		private void ResetTextTransform()
		{
			DOTween.Kill(moneyText.transform);
			moneyText.transform.localPosition = textInitialPosition;
			moneyText.transform.localScale = textInitialScale;
		}

		private void PlayFailedPurchaseAnimation()
		{
			currentFlashSequence?.Kill();
			ResetTextTransform();

			currentFlashSequence = DOTween.Sequence();

			currentFlashSequence.Append(overlayImage.DOFade(flashColor.a, flashDuration * 0.5f)
				.SetEase(fadeInEase));
			currentFlashSequence.Append(overlayImage.DOFade(0f, flashDuration * 0.5f)
				.SetEase(fadeOutEase));

			moneyText.transform
				.DOShakePosition(flashDuration, shakeStrength, shakeVibrato)
				.SetEase(Ease.OutQuad);

			moneyText.transform
				.DOPunchScale(Vector3.one * 0.2f, flashDuration, 1, 0.5f)
				.SetEase(Ease.OutQuad);
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