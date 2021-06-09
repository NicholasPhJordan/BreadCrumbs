using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int __lives;
    public int healthStrikeLimit = 3;
    public bool playerDidDie = false;

    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        //this makes sure that each time this scene is called it resets health to 0
        __lives = 0;
        //grabs body from scene to change
        _body = GetComponent<Rigidbody>();
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
        //first 2 ifs just reset the player position
        if (__lives == 1 || __lives == 2)
        {
            //sets player position where it started
            _body.position = new Vector3(-2, 2, -7);
        }
        //we want to give the player 3 hits before game over
        else if (__lives == healthStrikeLimit)
        {
            //also temperary, used for testing
            playerDidDie = true;
            //sets player position back to start
            _body.position = new Vector3(-2, 2, -7);
            //temperary until we get a Game Over screen
            Application.Quit();
        }
        else if (__lives > healthStrikeLimit)
            __lives = 0;
    }
}
