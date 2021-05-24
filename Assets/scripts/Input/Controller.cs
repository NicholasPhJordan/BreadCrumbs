using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 280.0f;

    float horizontal;
    float vertical;

    private void Update()
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

        Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
        Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);

        moveDirection = rotationToCamera * moveDirection;
        Quaternion rotationMoveDirection = Quaternion.LookRotation(moveDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationMoveDirection, rotationSpeed * Time.deltaTime);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
    }
}
