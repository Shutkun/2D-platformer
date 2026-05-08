using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _amountCoins = 0;

    public event UnityAction<int> AmountChanged;

    public void AddCoin()
    {
        _amountCoins++;
        AmountChanged?.Invoke(_amountCoins);
    }
}
