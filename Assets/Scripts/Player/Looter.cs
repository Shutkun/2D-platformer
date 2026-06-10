using System;
using UnityEngine;

public class Looter : MonoBehaviour
{
    public event Action GotTheCoin;
    public event Action<int> Healing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.DestroyObject();
            GotTheCoin?.Invoke();
            return;
        }

        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            firstAidKit.DestroyObject();
            Healing?.Invoke(firstAidKit.Healing);
        }
    }
}
