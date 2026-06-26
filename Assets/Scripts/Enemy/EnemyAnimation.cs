using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private readonly int _isMoving = Animator.StringToHash(nameof(_isMoving));
    private readonly int _playerIsClose = Animator.StringToHash(nameof(_playerIsClose));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayMove(bool isMoving)
    {
        _animator.SetBool(_isMoving, isMoving);
    }

    public void PlayAttack(bool playerIsClose)
    {
        _animator.SetBool(_playerIsClose, playerIsClose);
    }
}
