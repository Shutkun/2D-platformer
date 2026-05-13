using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _jumpForce = 15f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnJump();
    }

    private void OnJump()
    {
        if (_inputReader.OnJump())
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
