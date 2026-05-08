using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 8f;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private GameInput _gameInput;

    private Rigidbody2D _rigidbody;
    private float _gravityScale;
    private bool isOnLadder = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gravityScale = _rigidbody.gravityScale;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();
    }

    public void EnterLadder()
    {
        isOnLadder = true;
        _rigidbody.gravityScale = 0f;
    }

    public void ExitLadder()
    {
        isOnLadder = false;
        _rigidbody.gravityScale = _gravityScale;
    }

    private void Move()
    {
        Vector2 inputVector;

        if (isOnLadder)
        {
            inputVector = _gameInput.GetMovementWithVectorY();
            _rigidbody.linearVelocity = new Vector2(inputVector.x, inputVector.y * _movingSpeed);
        }
        else
        {
            inputVector = _gameInput.GetMovementWithoutVectorY();
            _rigidbody.linearVelocity = new Vector2(inputVector.x * _movingSpeed, _rigidbody.linearVelocity.y);
        }
    }


    private void Jump()
    {
        if (_gameInput.OnJump())
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
