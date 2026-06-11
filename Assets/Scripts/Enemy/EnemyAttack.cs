using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_damage);
        }
    }
}
