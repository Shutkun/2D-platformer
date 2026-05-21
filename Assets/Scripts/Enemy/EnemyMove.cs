using System;
using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private SearchPlayer _searchPlayer;
    [SerializeField] private Transform[] _wayPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeOfWaiting = 2f;
    [SerializeField] private float _stoppingDistance = 3f;

    public event Action<int> DirectionChanged;

    private int _currentWaypoint = 0;

    private Coroutine _coroutine;

    public bool IsMoving { get; private set; } = false;

    private void OnEnable()
    {
        _searchPlayer.FoundPlayer += MoveToPlayer;
        _searchPlayer.LostPlayer += StartRoaming;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Roam());
    }

    private void Update()
    {
        GetDirectionMoving();
    }

    private void OnDisable()
    {
        _searchPlayer.FoundPlayer -= MoveToPlayer;
        _searchPlayer.LostPlayer -= StartRoaming;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private int GetDirectionMoving()
    {
        int rightMoving = 1;
        int leftMoving = -1;

        if (transform.position.x > _wayPoint[_currentWaypoint].position.x)
        {
            DirectionChanged?.Invoke(leftMoving);
            return leftMoving;
        }
        else
        {
            DirectionChanged?.Invoke(rightMoving);
            return rightMoving;
        }
    }

    private void MoveToPlayer()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        Vector3 targetPosition = _searchPlayer.targetPosition.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        IsMoving = true;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        if (distanceToTarget <= _stoppingDistance)
        {
            IsMoving = false;
        }
    }

    private void StartRoaming()
    {
        _coroutine = StartCoroutine(Roam());
    }

    private IEnumerator Roam()
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_timeOfWaiting);

        while (enabled)
        {
            if (transform.position == _wayPoint[_currentWaypoint].position)
            {
                _currentWaypoint = ++_currentWaypoint % _wayPoint.Length;
                IsMoving = false;
                yield return _waitForSeconds;
            }

            IsMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, _wayPoint[_currentWaypoint].position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
