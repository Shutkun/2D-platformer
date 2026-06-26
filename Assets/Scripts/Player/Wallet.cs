using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Looter _lootter;

    public event Action<int> AmountChanged;

    private int _amountCoins = 0;

    private void OnEnable()
    {
        _lootter.GotTheCoin += AddCoin;
    }

    private void OnDisable()
    {
        _lootter.GotTheCoin -= AddCoin;
    }

    public void AddCoin()
    {
        _amountCoins++;
        AmountChanged?.Invoke(_amountCoins);
    }
}
