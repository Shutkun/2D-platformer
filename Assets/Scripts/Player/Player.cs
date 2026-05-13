using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action gotTheCoin;
    public event Action enterLadder;
    public event Action exitLadder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out _))
        {
            gotTheCoin?.Invoke();
            return;
        }

        if (collision.TryGetComponent<Ladder>(out _))
        {
            enterLadder?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            exitLadder?.Invoke();
        }
    }
}
