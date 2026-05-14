using System;
using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeOfWaiting = 2f;

    public event Action<int> DirectionChanged;

    private int _currentWaypoint = 0;

    private Coroutine _coroutine;

    public bool IsMoving { get; private set; } = false;

    private void Start()
    {
        _coroutine = StartCoroutine(MoveWithDelay());
    }

    private void Update()
    {
        GetDirectionMoving();
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
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

    private IEnumerator MoveWithDelay()
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
