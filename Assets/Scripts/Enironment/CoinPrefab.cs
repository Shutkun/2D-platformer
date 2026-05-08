using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class CoinPrefab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            wallet.AddCoin();
            Destroy(gameObject);
        }
    }
}
