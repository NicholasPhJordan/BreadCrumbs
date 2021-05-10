using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    //this will change from false to true if the lighting power up is false
    bool powerLighting = false;

    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerLighting == false)
        {
            _light.color = Color.Lerp(new Color(255, 220, 189, 255), new Color(0, 0, 0, 255), Time.deltaTime / 30);
        }
    }
}
