using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private InputReader _inputRader;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputRader.InputChanged += SetMove;
    }

    private void OnDisable()
    {
        _inputRader.InputChanged -= SetMove;
    }

    private void SetMove(Vector2 vector2)
    {
        _animator.SetFloat("Horizontal", vector2.x);
        _animator.SetFloat("Speed", _inputRader.InputVector.sqrMagnitude);
    }
}
