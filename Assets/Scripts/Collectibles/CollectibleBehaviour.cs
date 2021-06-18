using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{

    [Tooltip("The amount each collectable is worth")]
    [SerializeField]
    public int _scoreAmount;
    [SerializeField]
    private float _respawnTime;
    private static int _round;

    public static int Round
    {
        get { return _round; }
    }

    //resets the collectibles position after set amount of time and increases round counter
    public void ResetCollectible()
    {
        _round += 1;
        Invoke("ResetPosition", _respawnTime);
    }

    //resets the collectibles position
    private void ResetPosition()
    {
        transform.position =
            new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    //Collision with the "Player" will destroy the object and update the score
    void OnTriggerEnter(Collider other)
    {
        //move the collectable out of sight
        transform.position =
            new Vector3(transform.position.x, -3, transform.position.z);
        //update the collected variable
        GameManager.AddCollectable(this);
    }
}
