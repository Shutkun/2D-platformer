using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class EnemyAttackArea : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider;

    private void Awake()
    {
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    public void PolygonColliderTurnOff()
    {
        _polygonCollider.enabled = false;
    }

    public void PolygonColloderTurnOn()
    {
        _polygonCollider.enabled = true;
    }
}

