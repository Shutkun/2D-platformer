using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 8f;
    [Space]
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;

    private float _gravityScale;
    private bool isOnLadder = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gravityScale = _rigidbody.gravityScale;
    }

    private void OnEnable()
    {
        GameEventManager.Instance.EnterLadder += EnterLadder;
        GameEventManager.Instance.ExitLadder += ExitLadder;
        GameEventManager.Instance.InputChanged += Move;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.EnterLadder -= EnterLadder;
        GameEventManager.Instance.ExitLadder -= ExitLadder;
        GameEventManager.Instance.InputChanged -= Move;
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

    private void Move(Vector2 inputVector)
    {
        if (isOnLadder)
        {
            _rigidbody.linearVelocity = new Vector2(inputVector.x, inputVector.y * _movingSpeed);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector2(inputVector.x * _movingSpeed, _rigidbody.linearVelocity.y);
        }
    }
}
