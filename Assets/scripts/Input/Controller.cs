using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed;

    float horizontal;
    float vertical;

    public void OnMoveInput(float vertical, float horizontal)
    {
        this.vertical = vertical;
        this.horizontal = horizontal;
    }
}
