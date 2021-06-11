using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int _lives;
    public int lifeLimit = 3;
    public int playerDidDie = 0;

    public Rigidbody _body;
    public GameObject OverScreen;

    // Start is called before the first frame update
    void Start()
    {
        //this makes sure that each time this scene is called it resets health to 0
        _lives = 0;
        //this will grab the player object
        _body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //the enemy will hold the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //this adds a strike to health 
            _lives += 1;
            transform.position = new Vector3(-1, 2, -7);
        }
    }

    public void GameOverScreen()
    {
        //this checks if the Game Over screen in visible or not
        if(OverScreen != null)
        {
            //sets game over screen to be visible
            OverScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //we want to give the player 3 hits before game over
        if (_lives == lifeLimit)
        {
            //also temperary, used for testing
            playerDidDie += 1;
            //Game Over Screen
            GameOverScreen();
        }
        else if (_lives > lifeLimit)
            _lives = 0;
    }
}
