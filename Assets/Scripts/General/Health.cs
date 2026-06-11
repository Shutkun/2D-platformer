using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private bool _isNPC;
    [Space]
    [SerializeField] private Looter _looter;


    public int CurrentValue { get; private set; }
    public int MaxValue => _maxValue;

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    private void OnEnable()
    {
        GameEventManager.Instance.Healing += Heal;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.Healing -= Heal;
    }

    public void TakeDamage(int damage)
    {
        CurrentValue -= damage;

        if (_isNPC)
        {
            Debug.Log($"Враг получил {damage} урона, у него осталось {CurrentValue} здоровья.");
        }
        else
        {
            Debug.Log($"Игрок получил {damage} урона, у него осталось {CurrentValue} здоровья.");
        }

        if (CurrentValue <= 0)
        {
            GameEventManager.Instance.TriggerCharacterDied();
        }
    }

    public void Heal(int healthPower)
    {
        if (_isNPC == false)
        {
            CurrentValue += healthPower;

            if (CurrentValue > MaxValue)
            {
                CurrentValue = _maxValue;
            }

            Debug.Log("Игрок поднял аптечку, теперь у него " + CurrentValue);
        }
    }
}
