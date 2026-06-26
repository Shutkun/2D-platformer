using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _stoppingDistance = 1.7f;
    [Space]
    [SerializeField] private RotationObject _rotationObject;

    public bool IsMoving { get; private set; } = false;
    public bool PlayerIsClose { get; private set; } = false;

    public void Chasing(Vector3 targetPosition)
    {
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

        _rotationObject.FlipHorizontalOrientation(targetPosition);
    }
}
