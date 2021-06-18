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

    //resets the collectibles position after set amount of time and increases round counter
    public void ResetCollectible()
    {
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
