using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    private readonly int PlayerIsClose = Animator.StringToHash(nameof(PlayerIsClose));

    [SerializeField] private EnemyMover _mover;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayMove(int direction)
    {
        _animator.SetBool(IsMoving, _mover.IsMoving);
    }

    public void PlayAttack(int direction)
    {
        _animator.SetBool(PlayerIsClose, _mover.PlayerIsClose);
    }
}
