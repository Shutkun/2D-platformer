using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Looter _lotter;

    private int _amountCoins = 0;

    public event UnityAction<int> AmountChanged;

    private void OnEnable()
    {
        _lotter.GotTheCoin += AddCoin;
    }

    private void OnDisable()
    {
        _lotter.GotTheCoin -= AddCoin;
    }

    public void AddCoin()
    {
        _amountCoins++;
        AmountChanged?.Invoke(_amountCoins);
    }
}
