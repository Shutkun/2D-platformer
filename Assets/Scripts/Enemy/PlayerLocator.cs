using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
    [SerializeField] private float _distanceChasing = 10f;
    [Space]
    [SerializeField] private Player _target;

    private bool _isFoundTarget;

    public Vector3 TargetPosition { get; private set; }

    private void Update()
    {
        TrackingDistanceToTarget();
    }

    private void TrackingDistanceToTarget()
    {
        TargetPosition = _target.gameObject.transform.position;
        Vector3 distance = TargetPosition - transform.position;
        distance.y = 0;
        float distanceSq = distance.sqrMagnitude;

        DetectedTarget(distanceSq);
    }

    private void DetectedTarget(float distance)
    {
        if (distance <= _distanceChasing)
        {
            _isFoundTarget = true;
            GameEventManager.Instance.TriggerFoundTarget(_isFoundTarget);
        }
        else
        {
            _isFoundTarget = false;
            GameEventManager.Instance.TriggerLostTarget(_isFoundTarget);
        }
    }
}
