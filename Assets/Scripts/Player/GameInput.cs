using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _actions;
    private Vector2 _inputVector;

    public Vector2 InputVector => _inputVector;

    private void Awake()
    {
        _actions = new PlayerInputActions();
        _actions.Enable();
    }

    private void Update()
    {
        _inputVector = _actions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMovementWithoutVectorY()
    {
        Vector2 moveVectorX = new Vector2(_inputVector.x, 0);

        return moveVectorX;
    }

    public Vector2 GetMovementWithVectorY()
    {
        Vector2 moveVectorY = new Vector2(_inputVector.x, _inputVector.y);

        return moveVectorY;
    }

    public bool OnJump()
    {
        return _actions.Player.Jump.triggered;
    }
}