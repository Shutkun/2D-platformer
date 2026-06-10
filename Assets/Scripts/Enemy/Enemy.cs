using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private SearchPlayer _searchPlayer;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private AttackAnimation _attackAnimation;

    private bool _isCatchTarget = false;

    private void OnEnable()
    {
        _searchPlayer.FoundPlayer += CheckTarget;
        _searchPlayer.LostPlayer += CheckTarget;
    }

    private void OnDisable()
    {
        _searchPlayer.FoundPlayer -= CheckTarget;
        _searchPlayer.LostPlayer -= CheckTarget;
    }

    private void Update()
    {
        PlayAction();
        Die();
    }

    public void ApplyDamage(int damage)
    {
        _enemyHealth.TakeDamage(damage);
    }

    private void PlayAction()
    {
        if (_isCatchTarget)
        {
            if (_enemyMover.PlayerIsClose)
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
        _enemyAnimation.SetMove(_enemyMover.Direction);
        _enemyMover.StartRoaming();
    }

    private void FollowToTarget()
    {
        _enemyAnimation.SetMove(_enemyMover.Direction);
        _enemyMover.Сhasing(_searchPlayer.PlayerPosition);
    }

    private void Attack()
    {
        _enemyAnimation.SetMove(_enemyMover.Direction);
        _attackAnimation.SetAttack(_enemyMover.Direction);
    }

    private void StopAttack()
    {
        _attackAnimation.SetAttack(_enemyMover.Direction);
    }

    private void Die()
    {
        if (_enemyHealth.CurrentHealth <= 0)
        {
            Debug.Log("Враг умер!");
            Destroy(gameObject);
        }
    }

    private void CheckTarget(bool isTarget) =>
        _isCatchTarget = isTarget;
}