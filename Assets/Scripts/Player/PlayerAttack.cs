using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [Space]
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        GameEventManager.Instance.TargetClosed += Attack;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.TargetClosed -= Attack;
    }

    private void Attack(Enemy enemy)
    {
        Debug.Log("Attack");
        enemy.ApplyDamage(_damage);
    }
}
