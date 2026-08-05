using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class AbilityTimer : MonoBehaviour
{
    [SerializeField] private AbilityConfig _config;
    [SerializeField] private TextMeshProUGUI _text;

    public event Action TimerEnded;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _config.CooldownStarted += UpdateText;
    }

    private void OnDisable()
    {
        _config.CooldownStarted -= UpdateText;
    }

    private void UpdateText(float count)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(Countdown(count));
    }

    private IEnumerator Countdown(float count)
    {
        WaitForSeconds delay = new WaitForSeconds(1);

        while (count >= 0)
        {
            _text.text = count.ToString();
            count--;
            if (count < 0)
            {
                _text.text = " ";
                TimerEnded?.Invoke();
            }

            yield return delay;
        }
    }
}
