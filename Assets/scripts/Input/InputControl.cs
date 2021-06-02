using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }

public class InputControl : MonoBehaviour
{
    PlayerControls controls;
    public MoveInputEvent moveInputEvent;

    private void Awake()
    {
        //this grabs the input system
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        //this enables the controls called Gameplayer
        controls.Gameplay.Enable();
        //this calls what happens when actions are performed
        controls.Gameplay.Movement.performed += OnMovePerformed;
        //this calls what happens when actions are canceled
        controls.Gameplay.Movement.canceled += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        //this reads the values of the inputs 
        Vector2 moveInput = context.ReadValue<Vector2>();
        //this allows the events to be called
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
    }
}
