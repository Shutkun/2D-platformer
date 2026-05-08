using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMove>(out PlayerMove player))
        {
            player.EnterLadder();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMove>(out PlayerMove player))
        {
            player.ExitLadder();
        }
    }
}
