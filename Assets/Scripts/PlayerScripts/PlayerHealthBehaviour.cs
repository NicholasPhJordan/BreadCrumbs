using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public int _lives;
    public float _deathTimer = 0.0f;
    public int lifeLimit = 3;
    public bool GameOver = false;
    public float playersMoveSpeed = 0.08f;
    public float playersRotationSpeed = 1000;
    public Controller Player; 
    public Rigidbody _body;


    [SerializeField]
    private Image[] _life;

    //varible to hold player starting position
    private Vector3 homePosition;

    // Start is called before the first frame update
    void Start()
    {
        //this makes sure that each time this scene is called it resets health to 0
        _lives = 0;
        //this will grab the player object
        _body = GetComponent<Rigidbody>();

        //grabs player starting position
        homePosition = transform.position =
            new Vector3(transform.position.x, 
                        transform.position.y, 
                        transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //the enemy will hold the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("has collided");
            //this adds a strike to health 
            _life[_lives].enabled = false;
            _lives += 1;
            Player.moveSpeed = 0;
            Player.rotationSpeed = 0;
            Invoke("PlayerPosition", 2f);
        }
    }

    void PlayerPosition()
    {
        _deathTimer = 0;
        //no longer hardset, resets based off player starting position
        transform.position = homePosition;
        Player.moveSpeed += playersMoveSpeed;
        Player.rotationSpeed += playersRotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //we want to give the player 3 hits before game over
        if (_lives == lifeLimit)
        {
            //sets gameOver to true
            GameManager.SetGameOver = true;
            GameOver = true;
        }
        else if (_lives > lifeLimit)
        {
            _lives = 0;
            GameManager.SetGameOver = false;
        }
    }
}
