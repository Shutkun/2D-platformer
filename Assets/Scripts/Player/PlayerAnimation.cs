using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private readonly int _speed = Animator.StringToHash(nameof(_speed));
    private readonly int _onAttack = Animator.StringToHash(nameof(_onAttack));

    [SerializeField] private float _cooldown = 1.5f;

    private Animator _animator;
    private Coroutine _coroutine;

    private bool _canAttack = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        StopCoroutine();
    }

    public void Attack()
    {
        if (_canAttack == false)
        {
            return;
        }

        _canAttack = false;

        PlayAttack();
        _coroutine = StartCoroutine(Cooldown());
    }

    public void PlayMove(Vector2 vector2)
    {
        _animator.SetFloat(_speed, vector2.sqrMagnitude);
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }

    private void PlayAttack()
    {
        _animator.SetTrigger(_onAttack);
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
