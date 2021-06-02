using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 280.0f;

    float horizontal;
    float vertical;

    private Rigidbody _body;

    void Start()
    {
        //grabs the light component to allow change
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //this is a new value that always direction to equal the forward of vertical and horizontal
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

        //normalizes the vectore so diagnal isnt faster
        moveDirection = moveDirection.normalized;

        Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);

        //this will grab the Quaternion of the rotations and direction
        Quaternion rotationMoveDirection = Quaternion.LookRotation(moveDirection, Vector3.up);

        //this will set the rotation value to include the direction and allow player to
        //rotate towards the direction it is moving
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationMoveDirection, rotationSpeed * Time.deltaTime);

        if (moveDirection.magnitude > 0)
        {
            rotationMoveDirection = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationMoveDirection, rotationSpeed * Time.deltaTime);
        }

        //this will tranform the value of the position depending on speed and direction
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        //grabs values of vertical and horizontal
        this.vertical = vertical;
        this.horizontal = horizontal;
    }
}
