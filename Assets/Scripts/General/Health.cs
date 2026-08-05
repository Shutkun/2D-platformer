using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public event Action<int> ValueChange;

    public int CurrentValue { get; private set; }
    public int MaxValue => _maxValue;

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    public void TakeDamage(int damage) =>
        ChangeValue(-damage);

    public void Heal(int healthPower) =>
       ChangeValue(healthPower);

    private void ChangeValue(int value)
    {
        if (CurrentValue > _maxValue)
        {
            return;
        }

        if (CurrentValue <= 0)
        {
            Destroy(gameObject);
            return;
        }

        CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _maxValue);
        ValueChange?.Invoke(CurrentValue);
    }
}

