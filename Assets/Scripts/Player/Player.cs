using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private int _healPower = 30;

    public event Action GotTheCoin;
    public event Action EnterLadder;
    public event Action ExitLadder;
    public event Action <Enemy> TargetClosed;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            Debug.Log("У игрока осталось " + _currentHealth + " ХП");
        }
        else
        {
            Debug.Log("Игрок умер!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.DestroyObject();
            GotTheCoin?.Invoke();
            return;
        }

        if (collision.TryGetComponent<Ladder>(out _))
        {
            EnterLadder?.Invoke();
        }

        if (collision.TryGetComponent<Enemy>(out Enemy enemy) )
        {
            TargetClosed?.Invoke(enemy);
        }

        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            firstAidKit.DestroyObject();
            Healing();
            Debug.Log("Игрок поднял аптечку, теперь у него " + _currentHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ladder>(out _))
        {
            ExitLadder?.Invoke();
        }
    }

    private void Healing()
    {
        if((_currentHealth +=_healPower) <= _maxHealth)
        {
            _currentHealth += _healPower;
        }
        else
        {
            _currentHealth = _maxHealth;
        }
    }
}
