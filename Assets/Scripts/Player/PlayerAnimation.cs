using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private readonly int Speed = Animator.StringToHash(nameof(Speed));
    private readonly int HorizontalAxis = Animator.StringToHash(nameof(HorizontalAxis));
    private readonly int Direction = Animator.StringToHash(nameof(Direction));

    [SerializeField] private InputReader _inputRader;

    public float CurrentDirection { get; private set; } = 1f;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameEventManager.Instance.InputChanged += SetMove;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.InputChanged -= SetMove;
    }

    private void SetMove(Vector2 vector2)
    {
        _animator.SetFloat(HorizontalAxis, vector2.x);
        _animator.SetFloat(Speed, _inputRader.InputVector.sqrMagnitude);

        if (vector2.x != 0)
        {
            CurrentDirection = Mathf.Sign(vector2.x);
        }

        _animator.SetFloat(Direction, CurrentDirection);
    }
}
