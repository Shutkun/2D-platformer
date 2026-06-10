using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Looter _looter;

    public event Action EnterLadder;
    public event Action ExitLadder;
    public event Action<Enemy> TargetClosed;

    private void Update()
    {
        Die();
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            EnterLadder?.Invoke();
        }

        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            TargetClosed?.Invoke(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            ExitLadder?.Invoke();
        }
    }

    private void Die()
    {
        if (_health.CurrentHealth <= 0)
        {
            Debug.Log("Игрок умер!");
            Destroy(gameObject);
        }
    }
}
