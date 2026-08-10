using System;
using UnityEngine;

public class AbilityConfig : MonoBehaviour
{
    [SerializeField] private float _timeWork = 6.0f;
    [SerializeField] private float _cooldown = 4.0f;

    public event Action<float,float> onAbility;

    public float TimeWork => _timeWork;

    public void StartAbility()
    {
        onAbility?.Invoke(_timeWork, _cooldown);
    }
}
