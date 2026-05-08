using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeOfWaiting = 2f;

    private int _currentWaypoint = 0;
    private bool _isMoving = true;

    private Coroutine _coroutine;

    public bool IsMoving => _isMoving;

    private void Start()
    {
        _coroutine = StartCoroutine(MoveWithDelay());
    }

    private void OnDisable()
    {
        StopCoroutine(MoveWithDelay());
    }

    public int GetDirectionMoving()
    {
        int rightMoving = 1;
        int leftMoving = -1;

        if (transform.position.x > _wayPoint[_currentWaypoint].position.x)
        {
            return leftMoving;
        }
        else
        {
            return rightMoving;
        }
    }

    private IEnumerator MoveWithDelay()
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_timeOfWaiting);

        while (true)
        {
            if (transform.position == _wayPoint[_currentWaypoint].position)
            {
                _currentWaypoint = ++_currentWaypoint % _wayPoint.Length;
                _isMoving = false;
                yield return _waitForSeconds; 
            }
            
            _isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, _wayPoint[_currentWaypoint].position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
