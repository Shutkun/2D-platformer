using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Looter _looter;

    public event Action EnterLadder;
    public event Action ExitLadder;

    private void OnEnable()
    {
        _health.CharacterDied += Die;
        _looter.Healing += _health.Heal;
    }

    private void OnDisable()
    {
        _health.CharacterDied -= Die;
        _looter.Healing -= _health.Heal;
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
        if (_health.CurrentValue <= 0)
        {
            Debug.Log("Игрок умер!");
            Destroy(gameObject);
        }
    }
}
