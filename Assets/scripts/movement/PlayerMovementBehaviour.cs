using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Tooltip("How fast the p[layer will move.")]
    [SerializeField]
    private float _moveSpeed;
    [Tooltip("This grabs the wanted actors body value")]
    private Rigidbody _rigidbody;
    [Tooltip("A reference to the CharacterController to move.")]
    public CharacterController characterController;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _velocity = direction * _moveSpeed * Time.deltaTime;
    }

    internal void Move(object moveDirection)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _velocity);
    }

}
