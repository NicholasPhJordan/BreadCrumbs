using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int _lives;
    public float _deathTimer = 0.0f;
    public int lifeLimit = 3;
    public bool playerDidDie = false;
    public float playersMoveSpeed = 0.08f;
    public float playersRotationSpeed = 1000;
    public Controller Player; 

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
            Player.moveSpeed = 0;
            Player.rotationSpeed = 0;
            Invoke("PlayerPosition", 2f);
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

    void PlayerPosition()
    {
        _deathTimer = 0;
        transform.position = new Vector3(-1.5f, 1.84f, -7.07f);
        Player.moveSpeed += playersMoveSpeed;
        Player.rotationSpeed += playersRotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //we want to give the player 3 hits before game over
        if (_lives == lifeLimit)
        {
            //also temperary, used for testing
            playerDidDie = true;
            //Game Over Screen
            GameOverScreen();
        }
        else if (_lives > lifeLimit)
            _lives = 0;
    }
}
