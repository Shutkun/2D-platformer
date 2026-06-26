using UnityEngine;

public class RotationObject : MonoBehaviour
{
    public void FlipHorizontalOrientation(Vector3 targetPosition)
    {
        UpdateRotation(transform.position.x > targetPosition.x);
    }

    public void FlipHorizontalOrientation(Vector2 inputVector)
    {
        if (inputVector.x != 0)
        {
            UpdateRotation(inputVector.x < 0);
        }
    }

    private void UpdateRotation(bool shouldFlip)
    {
        if (shouldFlip)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
