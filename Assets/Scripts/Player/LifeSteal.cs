using System.Collections;
using UnityEngine;

public class LifeSteal : MonoBehaviour
{
    [SerializeField] private int _healPower;
    [SerializeField] private int _damagePerTick;
    [SerializeField] private float _tickDelaySeconds;
    [Space]
    [SerializeField] private Health _targetHeal;

    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable component))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(DrainLifeLoop(component));
            }
        }
    }

    private void OnDisable()
    {
        StopDrain();
    }

    private void DrainLife(IDamageable target)
    {
        _targetHeal.Heal(_healPower);
        target.ApplyDamage(_damagePerTick);
    }

    private IEnumerator DrainLifeLoop(IDamageable target)
    {
        WaitForSeconds delay = new WaitForSeconds(_tickDelaySeconds);

        while (enabled)
        {
            DrainLife(target);
            yield return delay;
        }
    }

    private void StopDrain()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}
