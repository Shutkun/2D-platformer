using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    private readonly int HorizontalAxis = Animator.StringToHash(nameof(HorizontalAxis));
    private readonly int PlayerIsClose = Animator.StringToHash(nameof(PlayerIsClose));


    [SerializeField] private EnemyMover _mover;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMove(int direction)
    {
        _animator.SetBool(IsMoving, _mover.IsMoving);
        _animator.SetFloat(HorizontalAxis, direction);
    }

    public void SetAttack(int direction)
    {
        _animator.SetBool(PlayerIsClose, _mover.PlayerIsClose);
        _animator.SetFloat(HorizontalAxis, direction);
    }
}
