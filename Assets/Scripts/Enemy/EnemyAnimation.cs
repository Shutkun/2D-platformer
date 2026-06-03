using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    private readonly int HorizontalAxis = Animator.StringToHash(nameof(HorizontalAxis));

    [SerializeField] private EnemyMover _enemyMove;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMove(int direction)
    {
        _animator.SetBool(IsMoving, _enemyMove.IsMoving);
        _animator.SetFloat(HorizontalAxis, direction);
    }
}
