using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [Space]
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.TargetClosed += Attack;
    }

    private void OnDisable()
    {
        _player.TargetClosed -= Attack;
    }

    private void Attack(Enemy enemy)
    {
        Debug.Log("Attack");
        enemy.ApplyDamage(_damage);
    }
}
