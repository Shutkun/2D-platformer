using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Coin : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
