using DG.Tweening;
using MyGame.Example;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.UI
{
	public class MoneyFeedbackController : MonoBehaviour
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

		[Header("Purchase Feedback")]
		[SerializeField] private TextMeshProUGUI spendingTextPrefab;
		[SerializeField] private Transform spendingTextParent;
		[SerializeField] private float floatingTextDuration = 1f;
		[SerializeField] private float floatingTextDistance = 50f;
		[SerializeField] private float scaleMultiplier = 1.2f;

		private Sequence currentFlashSequence;
		private Vector3 textInitialPosition;
		private Vector3 textInitialScale;

		private void Start()
		{
			playerPurchaseManager.OnBuyItem += OnItemPurchased;
			playerPurchaseManager.OnPurchaseFailed += OnPurchaseFailed;

			textInitialScale = moneyText.transform.localScale;
			textInitialPosition = moneyText.transform.localPosition;
		}

		private void OnItemPurchased(float price)
		{
			ShowSpendingText(price);
		}

		private void OnPurchaseFailed()
		{
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

		private void ShowSpendingText(float amount)
		{
			var spendingText = Instantiate(spendingTextPrefab, spendingTextParent);
			spendingText.text = $"-{amount:F0}$";

			Sequence sequence = DOTween.Sequence();

			spendingText.transform.localScale = Vector3.zero;
			spendingText.alpha = 0f;

			sequence.Append(spendingText.transform
				.DOScale(Vector3.one * scaleMultiplier, floatingTextDuration * 0.2f)
				.SetEase(Ease.OutBack));

			sequence.Join(spendingText.DOFade(1f, floatingTextDuration * 0.2f));

			sequence.Append(spendingText.transform
				.DOScale(Vector3.one, floatingTextDuration * 0.1f));

			sequence.Join(spendingText.transform
				.DOLocalMoveY(spendingText.transform.localPosition.y + floatingTextDistance, floatingTextDuration)
				.SetEase(Ease.OutQuad));

			sequence.Join(spendingText.transform
				.DOLocalRotate(new Vector3(0, 0, 10f), floatingTextDuration)
				.SetEase(Ease.InQuad));

			sequence.Append(spendingText.DOFade(0f, floatingTextDuration * 0.3f));

			sequence.OnComplete(() => { Destroy(spendingText.gameObject); });
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