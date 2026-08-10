using UnityEngine;
using UnityEngine.UI;

public class SlowCastBar : MonoBehaviour
{
    [SerializeField] private AbilityConfig _abilityConfig;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.interactable = false;
        SetValue();
    }

    private void SetValue()
    {
        float minValue = 0;
        _slider.maxValue = _abilityConfig.TimeWork;
        _slider.value = _slider.maxValue;
        _slider.minValue = minValue;
    }

    public void FillSlider()
    {
        float speedRecovery = 1.2f;

        while (_slider.value < _slider.maxValue)
        {
            _slider.value += speedRecovery;

            if (_slider.value > _slider.maxValue)
            {
                _slider.value = _slider.maxValue;
            }
        }
    }

    public void LowerSlider()
    {
        _slider.value--;

        if (_slider.value <= 0)
        {
            return;
        }
    }
}
