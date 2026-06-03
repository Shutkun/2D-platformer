using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private PlayerInputActions _actions;
    private Vector2 _inputVector;

    public event Action<Vector2> InputChanged;
    public event Action OnAttack;
    public Vector2 InputVector => _inputVector;

    private void Awake()
    {
        _actions = new PlayerInputActions();
        _actions.Enable();

        _actions.Player.Attack.started += Attack_started;
    }

    private void Update()
    {
        GiveInput();
    }

    public bool OnJump()
    {
        return _actions.Player.Jump.triggered;
    }

    private void Attack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke();
    }

    private void GiveInput()
    {
        _inputVector = _actions.Player.Move.ReadValue<Vector2>();
        InputChanged?.Invoke(_inputVector);
    }
}