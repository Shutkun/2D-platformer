using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeOfWaiting = 2f;
    [SerializeField] private float _stoppingDistance = 1f;
    [Space]
    [SerializeField] private Transform[] _wayPoint;

    private int _currentWaypoint = 0;

    private Coroutine _coroutine;

    public bool IsMoving { get; private set; } = false;

    public bool PlayerIsClose { get; private set; } = false;

    public int Direction { get; private set; } = 0;

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    public void Сhasing(Vector3 targetPosition)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        Vector3 directionToTarget = targetPosition - transform.position;
        directionToTarget.y = 0;

        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget > _stoppingDistance)
        {
            PlayerIsClose = false;
            IsMoving = true;

            Vector3 moveDirection = directionToTarget.normalized;
            Vector3 newPosition = transform.position + moveDirection * (_speed * Time.deltaTime);
            transform.position = newPosition;
        }
        else
        {
            IsMoving = false;
            PlayerIsClose = true;
        }

        GetDirectionMoving(targetPosition);
    }


    public void StartRoaming()
    {
        PlayerIsClose = false;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Roam());
        }

        GetDirectionMoving(_wayPoint[_currentWaypoint].position);
    }

    private IEnumerator Roam()
    {
        PlayerIsClose = false;

        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeOfWaiting);

        while (enabled)
        {
            if (transform.position.x == _wayPoint[_currentWaypoint].position.x)
            {
                _currentWaypoint = ++_currentWaypoint % _wayPoint.Length;
                IsMoving = false;
                yield return waitForSeconds;
            }

            IsMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, _wayPoint[_currentWaypoint].position, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void GetDirectionMoving(Vector3 targetPosition)
    {
        if (transform.position.x > targetPosition.x)
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
    }
}
