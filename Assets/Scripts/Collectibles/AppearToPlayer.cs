using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearToPlayer : MonoBehaviour
{
    [Tooltip("The GameObject you want to turn off/on")]
    public GameObject item;

    //activate the MeshRenderer of the other object while player is in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            item.SetActive(true);
    }

    //when the player leaves the range, turn off MeshRenderer
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            item.SetActive(false);
    }
}
