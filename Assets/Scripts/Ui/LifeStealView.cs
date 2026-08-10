using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeStealView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private SlowCastBar _slowCastBar;
    [SerializeField] private TextMeshProUGUI _textTick;
    [SerializeField] private TextMeshProUGUI _textCooldown;


    public void DisableButton()
    {
        _button.gameObject.SetActive(false);
    }

    public void StartCooldown(float elapsedTime, float cooldown)
    {
        ChangeText(_textCooldown, elapsedTime, cooldown);
    }

    public void EnableButton()
    {
        _button.gameObject.SetActive(true);
    }

    public void StartTimer(float elapsedTime, float timeWork)
    {
        _slowCastBar.LowerSlider();

        ChangeText(_textTick, elapsedTime, timeWork);

        if (elapsedTime >= timeWork)
        {
            _slowCastBar.FillSlider();
        }
    }

    private void ChangeText(TextMeshProUGUI text, float elapsedTime, float durationTime)
    {
        text.text = $"{(int)(durationTime - elapsedTime)}";

        if ((int)(durationTime - elapsedTime) <= 0)
        {
            text.text = " ";
        }
    }
}
