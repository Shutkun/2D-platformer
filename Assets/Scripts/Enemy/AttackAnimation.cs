using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackAnimation : MonoBehaviour
{
    private readonly int PlayerIsClose = Animator.StringToHash(nameof(PlayerIsClose));
    private readonly int HorizontalAxis = Animator.StringToHash(nameof(HorizontalAxis));

    [SerializeField] private EnemyMover _enemyMove;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAttack(int direction)
    {
        _animator.SetBool(PlayerIsClose, _enemyMove.PlayerIsClose);
        _animator.SetFloat(HorizontalAxis, direction);
    }
}
