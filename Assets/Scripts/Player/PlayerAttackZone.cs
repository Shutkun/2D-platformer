using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class PlayerAttackZone : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void BoxCollider2DTurnOn()
    {
        _boxCollider2D.enabled = true;
    }

    private void BoxCollider2DTurnOff()
    {
        _boxCollider2D.enabled = false;
    }
}
