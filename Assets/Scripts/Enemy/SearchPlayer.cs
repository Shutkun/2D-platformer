using UnityEngine;
using UnityEngine.Events;

public class SearchPlayer : MonoBehaviour
{
    [SerializeField] private float _distanceChasing = 10f;
    [Space]
    [SerializeField] private Player _player;

    private bool _isFoundPlayer;

    public event UnityAction<bool> FoundPlayer;
    public event UnityAction<bool> LostPlayer;

    public Vector3 PlayerPosition { get; private set; }

    private void Update()
    {
        TrackingDistanceToPlayer();
    }

    private void TrackingDistanceToPlayer()
    {
        PlayerPosition = _player.gameObject.transform.position;
        Vector3 distance = PlayerPosition - transform.position;
        distance.y = 0;
        float distanceSq = distance.sqrMagnitude;

        DetectedPlayer(distanceSq);
    }

    private void DetectedPlayer(float distance)
    {
        if (distance <= _distanceChasing)
        {
            _isFoundPlayer = true;
            FoundPlayer?.Invoke(_isFoundPlayer);
        }
        else
        {
            _isFoundPlayer = false;
            LostPlayer?.Invoke(_isFoundPlayer);
        }
    }
}
