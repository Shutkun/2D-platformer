using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Looter _lotter;

    private int _amountCoins = 0;

    private void OnEnable()
    {
        GameEventManager.Instance.GotTheCoin += AddCoin;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.GotTheCoin -= AddCoin;
    }

    public void AddCoin()
    {
        _amountCoins++;
        GameEventManager.Instance.TriggerAmountChanged(_amountCoins);
    }
}
