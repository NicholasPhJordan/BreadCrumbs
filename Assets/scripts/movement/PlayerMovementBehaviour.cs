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

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //changes x and going foreward
        if (Input.GetButton("W"))
        {
            //this will create and give value to move
            float move = _moveSpeed * 5;
            //this will move the position of the _rigidbody
            _rigidbody.position += transform.forward * Time.deltaTime * move;
            //this will allow the player to move in the direction its facing
            _rigidbody.AddRelativeForce(new Vector3(-move, 0, 0), ForceMode.Impulse);
        }
        //rotates y
        else if (Input.GetButton("A"))
        {
            //this will rotate the _rigidbody to the left
            transform.Rotate(new Vector3(0, -_moveSpeed, 0) * Time.deltaTime * 100, Space.World);
        }
        //changes x and going backwards 
        else if (Input.GetButton("S"))
        {
            //this will create and give value to move
            float move = _moveSpeed * 5;
            //this will move the position of the _rigidbody
            _rigidbody.position -= transform.forward * Time.deltaTime * move;
            //this will allow the player to move in the direction its facing
            _rigidbody.AddRelativeForce(new Vector3(move, 0, 0), ForceMode.Impulse);
        }
        //rotates y
        else if (Input.GetButton("D"))
        {
            //this will rotate the _rigidbody to the right
            transform.Rotate(new Vector3(0, _moveSpeed, 0) * Time.deltaTime * 100, Space.World);
        }
    }
}
