using System.Collections;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _timeOfWaiting = 2f;
    [SerializeField] private float _speed = 3;
    [Space]
    [SerializeField] private RotationObject _rotationObject;
    [SerializeField] private Transform[] _wayPoint;

    private Coroutine _coroutine;

    private int _currentWaypoint = 0;

    public bool IsMoving { get; private set; } = false;
    public bool PlayerIsClose { get; private set; } = false;

    private void OnDisable()
    {
        StopRoaming();
    }

    public void StartRoaming()
    {
        PlayerIsClose = false;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Roam());
        }

        _rotationObject.FlipHorizontalOrientation(_wayPoint[_currentWaypoint].position);
    }

    public void StopRoaming()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
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
}
