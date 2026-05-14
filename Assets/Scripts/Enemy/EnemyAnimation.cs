using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    private readonly int HorizontalAxis = Animator.StringToHash(nameof(HorizontalAxis));

    [SerializeField] private EnemyMove _enemyMove;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyMove.DirectionChanged += SetMove;
    }

    private void OnDisable()
    {
        _enemyMove.DirectionChanged -= SetMove;
    }

    private void SetMove(int direction)
    {
        _animator.SetBool(IsMoving, _enemyMove.IsMoving);
        _animator.SetFloat(HorizontalAxis, direction);
    }
}
