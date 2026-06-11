using UnityEngine;

public class Looter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.DestroyObject();
            GameEventManager.Instance.TriggerGotTheCoin();
            return;
        }

        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            firstAidKit.DestroyObject();
            GameEventManager.Instance.TriggerHealing(firstAidKit.Healing);
        }
    }
}
