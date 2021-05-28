using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            player.transform.position += player.transform.forward * playerSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            player.transform.position -= player.transform.forward * playerSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * playerSpeed * Time.deltaTime * 30);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * playerSpeed * Time.deltaTime * 30);
    }
}
