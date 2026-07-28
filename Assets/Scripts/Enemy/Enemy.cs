using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private PlayerLocator _playerLocator;
    [SerializeField] private EnemyAnimation _animation;

    private bool _isCatchTarget = false;


    private void OnEnable()
    {
        _playerLocator.FoundTarget += SetTarget;
        _playerLocator.LostTarget += SetTarget;
    }

    private void OnDisable()
    {
        _playerLocator.FoundTarget -= SetTarget;
        _playerLocator.LostTarget -= SetTarget;
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
            _patroller.StopRoaming();

            if (_chaser.PlayerIsClose)
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
        _animation.PlayMove(_patroller.IsMoving);
        _patroller.StartRoaming();
    }

    private void FollowToTarget()
    {
        _animation.PlayMove(_chaser.IsMoving);
        _chaser.Chasing(_playerLocator.TargetPosition);
    }

    private void Attack()
    {
        _animation.PlayMove(_chaser.IsMoving);
        _animation.PlayAttack(_chaser.PlayerIsClose);
    }

    private void StopAttack()
    {
        _animation.PlayAttack(_patroller.PlayerIsClose);
    }

    private void SetTarget(bool isTarget) =>
        _isCatchTarget = isTarget;
}