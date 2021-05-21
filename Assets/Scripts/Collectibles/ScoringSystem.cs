using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static float addScore;

    // Update is called once per frame
    void Update()
    {
        //UI that says score and shows the current player score 
        scoreText.GetComponent<Text>().text = "Score: " + addScore;
    }
}
