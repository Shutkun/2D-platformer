using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowCastBar : MonoBehaviour
{
    [SerializeField] private float _speedChangeSlider = 7f;
    [Space]
    [SerializeField] private AbilityConfig _abilityConfig;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _abilityConfig.TimerActiveStarted += StartLowerSlider;
        _abilityConfig.CooldownStarted += StartFillSlider;
    }

    private void Start()
    {
        _slider.interactable = false;

        SetValue();
    }

    private void OnDisable()
    {
        _abilityConfig.TimerActiveStarted -= StartLowerSlider;
        _abilityConfig.CooldownStarted -= StartFillSlider;

        StopActiveCorouutine();
    }

    private void SetValue()
    {
        float minValue = 0;

        _slider.maxValue = _abilityConfig.TimeWork;
        _slider.minValue = minValue;
        _slider.value = _slider.maxValue;
    }

    private void StartLowerSlider()
    {
        StopActiveCorouutine();

        _coroutine = StartCoroutine(LowerSliderLoop());
    }

    private void StartFillSlider(float obj)
    {
        StopActiveCorouutine();

        _coroutine = StartCoroutine(FillSliderLoop());
    }

    private void StopActiveCorouutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator FillSliderLoop()
    {
        float speedRecovery = 1.2f;
        WaitForSeconds delay = new WaitForSeconds(1);

        while (_slider.value < _abilityConfig.TimeWork)
        {
            _slider.value += speedRecovery;
            yield return delay;
        }
    }

    private IEnumerator LowerSliderLoop()
    {
        WaitForSeconds delay = new WaitForSeconds(1);

        while (_slider.value >= 0)
        {
            _slider.value--;
            _text.text = _slider.value.ToString();

            if (_slider.value <= 0)
            {
                yield return null;
                _text.text = string.Empty;
            }

            yield return delay;
        }
    }
}
