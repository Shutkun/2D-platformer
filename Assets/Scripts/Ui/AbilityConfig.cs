using System;
using System.Collections;
using UnityEngine;

public class AbilityConfig : MonoBehaviour
{
    [SerializeField] private float _timeWork = 6.0f;
    [SerializeField] private float _cooldown = 4.0f;
    [Space]
    [SerializeField] private LifeSteal _lifeSteal;

    private bool isReady = true;
    private Coroutine _coroutine;

    public event Action TimerActiveStarted;
    public event Action<float> CooldownStarted;
    public float TimeWork => _timeWork;

    private void OnDisable()
    {
        CancelAbilityCycle();
    }

    public void StartAbilityCycle()
    {
        if (isReady == false)
        {
            return;
        }

        CancelAbilityCycle();
        _coroutine = StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        WaitForSeconds timeWork = new WaitForSeconds(_timeWork);
        WaitForSeconds cooldown = new WaitForSeconds(_cooldown);

        _lifeSteal.gameObject.SetActive(isReady);
        TimerActiveStarted?.Invoke();

        yield return timeWork;

        isReady = false;
        _lifeSteal.gameObject.SetActive(isReady);
        CooldownStarted?.Invoke(_cooldown);

        yield return cooldown;

        isReady = true;
    }

    private void CancelAbilityCycle()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
