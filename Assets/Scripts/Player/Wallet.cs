using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _amountCoins = 0;

    public event UnityAction<int> AmountChanged;

    private void OnEnable()
    {
        _player.GotTheCoin += AddCoin;
    }

    private void OnDisable()
    {
        _player.GotTheCoin -= AddCoin;
    }

    public void AddCoin()
    {
        _amountCoins++;
        AmountChanged?.Invoke(_amountCoins);
    }
}
