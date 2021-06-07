using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int __lives;
    public int healthStrikeLimit = 3;
    public bool playerDidDie = false;

    // Start is called before the first frame update
    void Start()
    {
        //this makes sure that each time this scene is called it resets health to 0
        __lives = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //the enemy will hold the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //this adds a strike to health 
            __lives += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //we want to give the player 3 hits before game over
        if (__lives == healthStrikeLimit)
        {
            //also temperary, used for testing
            playerDidDie = true;
            //temperary until we get a Game Over screen
            Application.Quit();
        }
        else if (__lives > healthStrikeLimit)
            __lives = 0;
    }
}
