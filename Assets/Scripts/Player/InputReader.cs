using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private PlayerInputActions _actions;
    private Vector2 _inputVector;

    public event Action<Vector2> InputChanged;
    public Vector2 InputVector => _inputVector;

    private void Awake()
    {
        _actions = new PlayerInputActions();
        _actions.Enable();
    }

    private void Update()
    {
        GiveInput();
    }

    private void GiveInput()
    {
        _inputVector = _actions.Player.Move.ReadValue<Vector2>();
        InputChanged?.Invoke(_inputVector);
    }

    public bool OnJump()
    {
        return _actions.Player.Jump.triggered;
    }
}