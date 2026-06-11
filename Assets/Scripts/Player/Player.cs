using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Looter _looter;

    private void OnEnable()
    {
       GameEventManager.Instance.CharacterDied += Die;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.CharacterDied -= Die;
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            GameEventManager.Instance.TriggerEnterLadder();
        }

        if (collision.TryGetComponent<Enemy>(out Enemy targert))
        {
            GameEventManager.Instance.TriggerTargetClosed(targert);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            GameEventManager.Instance.TriggerExitLadder();
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
