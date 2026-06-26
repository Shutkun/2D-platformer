using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public event Action CharacterDied;

    public int CurrentValue { get; private set; }
    public int MaxValue => _maxValue;

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        CurrentValue -= damage;

        if (CurrentValue <= 0)
        {
            CharacterDied?.Invoke();
        }
    }

    public void Heal(int healthPower)
    {
        CurrentValue += healthPower;

        if (CurrentValue > MaxValue)
        {
            CurrentValue = _maxValue;
        }

        Debug.Log("Игрок поднял аптечку, теперь у него " + CurrentValue);
    }
}

