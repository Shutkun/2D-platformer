using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [Space]
    [SerializeField] private Looter _looter;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        _looter.Healing += AddHealth;
    }

    private void OnDisable()
    {
        _looter.Healing -= AddHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"Игрок получил {damage} урона, у него осталось {CurrentHealth} здоровья.");
    }

    public void AddHealth(int healthPower)
    {
        CurrentHealth += healthPower;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = _maxHealth;
        }

        Debug.Log("Игрок поднял аптечку, теперь у него " + CurrentHealth);
    }
}
