﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Rigidbody rbdy = collision.gameObject.GetComponent<Rigidbody>();

            //Stop Moving/Translating
            rbdy.velocity = Vector3.zero;

            //Stop rotating
            rbdy.angularVelocity = Vector3.zero;
        }
    }
}
