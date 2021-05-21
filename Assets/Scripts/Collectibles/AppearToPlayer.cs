using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearToPlayer : MonoBehaviour
{
    public GameObject collectable;

    //activate the MeshRenderer of the other object while player is in range
    private void OnTriggerEnter(Collider other)
    {
        collectable.GetComponent<MeshRenderer>().enabled = true;
    }

    //when the player leaves the range, turn off MeshRenderer
    private void OnTriggerExit(Collider other)
    {
        collectable.GetComponent<MeshRenderer>().enabled = false;
    }
}
