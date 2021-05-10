using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCrumbBehavior : MonoBehaviour
{
    [Tooltip("The amount each collectable is worth")]
    public float scoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0;
    }

    //Collision with the "Player" will destroy the object and update the score
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScoringSystem.addScore += scoreAmount;
            Destroy(gameObject);
        }
    }
}
