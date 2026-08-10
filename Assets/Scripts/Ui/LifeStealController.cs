using System.Collections;
using UnityEngine;

public class LifeStealController : MonoBehaviour
{
    [SerializeField] private AbilityConfig _abilityConfig;
    [SerializeField] private LifeStealView _view;
    [SerializeField] private LifeSteal _lifeSteal;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _abilityConfig.onAbility += ActivateAbility;
    }

    private void OnDisable()
    {
        _abilityConfig.onAbility -= ActivateAbility;
        DeactivateAbility();
    }

    private void ActivateAbility(float timeWork, float cooldown)
    {
        DeactivateAbility();
        _coroutine = StartCoroutine(RunAbilityCycle(timeWork, cooldown));
    }

    private void DeactivateAbility()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator RunAbilityCycle(float timeWork, float cooldown)
    {
        var elapsedTime = 0f;
        float timeToWait = 1f;
        WaitForSeconds wait = new WaitForSeconds(timeToWait);

        _lifeSteal.gameObject.SetActive(true);
        _view.DisableButton();
        while (elapsedTime < timeWork)
        {
            elapsedTime ++;
            _view.StartTimer(elapsedTime, timeWork);
            yield return wait;
        }

        _lifeSteal.gameObject.SetActive(false);

        elapsedTime = 0f;
        while (elapsedTime < cooldown)
        {
            elapsedTime ++;
            _view.StartCooldown(elapsedTime, cooldown);
            yield return wait;
        }

        _view.EnableButton();
    }
}
