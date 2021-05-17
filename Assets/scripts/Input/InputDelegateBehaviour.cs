using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehaviour : MonoBehaviour
{
    private PlayerControls _playerControls;
    private PlayerMovementBehaviour _playerMovement;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovementBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector2 moveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();
        //_playerMovement.Move(moveDirection);
        //Makes it move via X
        Vector3 directionMove = new Vector3(_playerControls.Player.Movement.ReadValue<Vector2>().x, 0, _playerControls.Player.Movement.ReadValue<Vector2>().y);
        _playerMovement.Move(directionMove);
    }
}
