using UnityEngine;
using UnityEngine.Events;

public class SearchPlayer : MonoBehaviour
{
    public event UnityAction FoundPlayer;
    public event UnityAction LostPlayer;

    public Transform targetPosition { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player target))
        {
            targetPosition = target.gameObject.transform;
            FoundPlayer?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            LostPlayer?.Invoke();
        }
    }
}
