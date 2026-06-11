using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 17f;
    [Space]
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ApplyForce();
    }

    private void ApplyForce()
    {
        if (_inputReader.OnJump())
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
