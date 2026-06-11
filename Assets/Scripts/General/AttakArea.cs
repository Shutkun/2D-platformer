using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class AttackArea : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider;

    private void Awake()
    {
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    public void TurnOffPolygonCollider()
    {
        _polygonCollider.enabled = false;
    }

    public void TurnOnPolygonColloder()
    {
        _polygonCollider.enabled = true;
    }
}

