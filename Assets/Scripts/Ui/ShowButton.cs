using UnityEngine;
using UnityEngine.UI;

public class ShowButton : MonoBehaviour
{
    [SerializeField] private AbilityTimer _timer;
    [SerializeField] private Button _button; 

    private void OnEnable()
    {
        _timer.TimerEnded += ActiveImage;
    }

    private void OnDisable()
    {
        _timer.TimerEnded -= ActiveImage;
    }

    private void ActiveImage()
    {
        _button.image.enabled = true;
        _button.interactable = true;
    }
}
