using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]

public class PlayerAnimationBehavior : MonoBehaviour
{
    [Tooltip("The animator attached to the player.")]
    [SerializeField]
    private Animator _playerAnimator;

    private Controller _controller;

    //public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerAnimator.SetFloat("Speed", _controller.GetPlayerSpeed);
    }
}
