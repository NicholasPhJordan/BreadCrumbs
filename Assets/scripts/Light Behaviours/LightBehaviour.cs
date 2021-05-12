using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [Tooltip("this will change from false to true if the lighting power up is false")]
    [SerializeField]
    private bool powerLighting;

    //this will grab the lighting comonent from an object to allow change 
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
            _light.color = Color.HSVToRGB(75, 75, 255);
        }
        else
        {
            //_light.color = Color.HSVToRGB(0, 0, 255);
        }
    }
}
