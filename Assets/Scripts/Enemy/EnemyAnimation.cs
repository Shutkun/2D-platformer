using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("IsMoving", _enemyMove.IsMoving);
        _animator.SetFloat("Horizontal", _enemyMove.GetDirectionMoving());
    }
}
