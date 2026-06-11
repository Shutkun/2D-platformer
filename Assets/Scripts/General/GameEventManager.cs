using System;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; private set; }

    public event Action GotTheCoin;
    public event Action<int> Healing;
    public event Action CharacterDied;
    public event Action EnterLadder;
    public event Action ExitLadder;
    public event Action<Enemy> TargetClosed;
    public event Action<bool> FoundTarget;
    public event Action<bool> LostTarget;
    public event Action<int> AmountChanged;
    public event Action<Vector2> InputChanged;
    public event Action OnAttack;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerGotTheCoin() => 
        GotTheCoin?.Invoke();

    public void TriggerHealing(int amount) => 
        Healing?.Invoke(amount);

    public void TriggerCharacterDied() => 
        CharacterDied?.Invoke();

    public void TriggerEnterLadder() => 
        EnterLadder?.Invoke();

    public void TriggerExitLadder() => 
        ExitLadder?.Invoke();

    public void TriggerTargetClosed(Enemy target) => 
        TargetClosed?.Invoke(target);

    public void TriggerFoundTarget(bool isFound) => 
        FoundTarget?.Invoke(isFound);

    public void TriggerLostTarget(bool isLost)=> 
        LostTarget?.Invoke(isLost);

    public void TriggerAmountChanged(int amount) => 
        AmountChanged?.Invoke(amount);

    public void TriggerInputChanged(Vector2 input) =>
        InputChanged?.Invoke(input); 

    public void TriggerOnAttack() => 
        OnAttack?.Invoke();
}
