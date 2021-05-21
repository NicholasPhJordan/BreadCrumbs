using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    [Tooltip("The amount each collectable is worth")]
    public float scoreAmount;

    //Collision with the "Player" will destroy the object and update the score
    void OnTriggerEnter(Collider other)
    {
        //add scoreAmount to the score
        ScoringSystem.addScore += scoreAmount;
        //move the collectable out of sight
        transform.position =
            new Vector3(transform.position.x, -3, transform.position.z);
        //update the collected variable
        GameManager.collected += 1;
    }
}
