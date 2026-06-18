using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private PlayerLocator _playerLocator;
    [SerializeField] private EnemyAnimation _animation;

    private bool _isCatchTarget = false;

    private void OnEnable()
    {
        GameEventManager.Instance.FoundTarget += SetTarget;
        GameEventManager.Instance.LostTarget += SetTarget;
        GameEventManager.Instance.CharacterDied += Die;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.FoundTarget -= SetTarget;
        GameEventManager.Instance.LostTarget -= SetTarget;
        GameEventManager.Instance.CharacterDied -= Die;
    }

    private void Update()
    {
        PlayAction();
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void PlayAction()
    {
        if (_isCatchTarget)
        {
            if (_mover.PlayerIsClose)
            {
                Attack();
            }
            else
            {
                StopAttack();
                FollowToTarget();
            }
        }
        else
        {
            StopAttack();
            Roam();
        }
    }

    private void Roam()
    {
        _animation.PlayMove(_mover.Direction);
        _mover.StartRoaming();
    }

    private void FollowToTarget()
    {
        _animation.PlayMove(_mover.Direction);
        _mover.Сhasing(_playerLocator.TargetPosition);
    }

    private void Attack()
    {
        _animation.PlayMove(_mover.Direction);
        _animation.PlayAttack(_mover.Direction);
    }

    private void StopAttack()
    {
        _animation.PlayAttack(_mover.Direction);
    }

    private void Die()
    {
        Debug.Log("Враг умер!");
        Destroy(gameObject);
    }

    private void SetTarget(bool isTarget) =>
        _isCatchTarget = isTarget;
}