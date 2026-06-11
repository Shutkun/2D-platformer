using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _amountConsText;

    private void OnEnable()
    {
        GameEventManager.Instance.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.AmountChanged -= DisplayAmount;
    }

    private void DisplayAmount(int amountCoins)
    {
        _amountConsText.text = "X " + amountCoins.ToString();
    }
}
