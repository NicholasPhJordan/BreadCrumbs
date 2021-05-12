using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventBehaviour : MonoBehaviour
{

    private PlayerMovementBehaviour _movement;


    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovementBehaviour>();
    }


}
