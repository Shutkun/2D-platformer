using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Horizontal", _gameInput.InputVector.x);
        _animator.SetFloat("Speed", _gameInput.InputVector.sqrMagnitude);
    }
}
