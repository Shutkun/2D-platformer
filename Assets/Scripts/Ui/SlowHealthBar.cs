using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlowHealthBar : MonoBehaviour
{
    [SerializeField] private float _speedChangeSlider = 7f;
    [Space]
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private float _targetValue;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider.interactable = false;

        SetValue();
        StartUpdateSlider();
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void SetValue()
    {
        float minValue = 0;

        _slider.maxValue = _health.MaxValue;
        _slider.minValue = minValue;
        _targetValue = _health.CurrentValue;
    }

    private void StartUpdateSlider()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(UpdateSliderLoop());
    }

    private IEnumerator UpdateSliderLoop()
    {
        while (enabled)
        {
            float current = _slider.value;
            _targetValue = _health.CurrentValue;

            while (Mathf.Abs(current - _targetValue) > 0.01f)
            {
                current = Mathf.MoveTowards(current, _targetValue, Time.deltaTime * _speedChangeSlider);
                _slider.value = current;
                yield return null;
            }

            _slider.value = _targetValue;
            yield return null;
        }
    }
}