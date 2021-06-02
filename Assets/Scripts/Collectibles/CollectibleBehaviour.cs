using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    [Tooltip("The amount each collectable is worth")]
    public int scoreAmount;

    public void ResetCollectible()
    {
        transform.position =
            new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    //Collision with the "Player" will destroy the object and update the score
    void OnTriggerEnter(Collider other)
    {
        //add scoreAmount to the score
        ScoringSystem.addScore += scoreAmount;
        //move the collectable out of sight
        transform.position =
            new Vector3(transform.position.x, -3, transform.position.z);
        //update the collected variable
        GameManager.AddCollectable(this);
    }
}
