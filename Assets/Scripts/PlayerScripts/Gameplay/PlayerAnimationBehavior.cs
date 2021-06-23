using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehavior : MonoBehaviour
{
    [Tooltip("The animator attached to the player.")]
    [SerializeField]
    private Animator _playerAnimator;

    public float testSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerAnimator.SetFloat("Speed", testSpeed);
    }
}
