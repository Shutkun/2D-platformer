using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private const string Moving = "IsMoving";
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private EnemyMove _enemyMove;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(Moving, _enemyMove.IsMoving);
        _animator.SetFloat(HorizontalAxis, _enemyMove.GetDirectionMoving());
    }
}
