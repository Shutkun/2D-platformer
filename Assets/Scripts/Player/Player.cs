using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action GotTheCoin;
    public event Action EnterLadder;
    public event Action ExitLadder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.DestroyObject();
            GotTheCoin?.Invoke();
            return;
        }

        if (collision.TryGetComponent<Ladder>(out _))
        {
            EnterLadder?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            ExitLadder?.Invoke();
        }
    }
}
