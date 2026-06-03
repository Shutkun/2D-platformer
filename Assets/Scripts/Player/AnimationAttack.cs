using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationAttack : MonoBehaviour
{
    private readonly int OnAttack = Animator.StringToHash(nameof(OnAttack));
    private readonly int Direction = Animator.StringToHash(nameof(Direction));

    [SerializeField] private float _cooldown = 2f;
    [Space]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private Animator _animator;
    private Coroutine _coroutine;

    private bool _canAttack = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputReader.OnAttack += Attack;
    }

    private void OnDisable()
    {
        _inputReader.OnAttack -= Attack;

        StopCoroutine();
    }

    private void Attack()
    {
        if (_canAttack == false)
        {
            return;
        }

        _canAttack = false;

        SetAttack();
        _coroutine = StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }

    private void SetAttack()
    {
        _animator.SetTrigger(OnAttack);
        _animator.SetFloat(Direction, _playerAnimation.CurrentDirection);
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
