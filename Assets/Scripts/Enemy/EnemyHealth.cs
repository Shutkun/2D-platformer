using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"Враг получил {damage} урона, у него осталось {CurrentHealth} здоровья.");
    }
}
