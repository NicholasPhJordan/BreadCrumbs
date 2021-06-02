using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [Tooltip("this will change from false to true if the lighting power up is false")]
    [SerializeField]
    public bool powerLighting;

    public float minBrightness;
    public float maxBrightness;
    public float brightTimer;

    private float _brightenRate;

    //this will grab the lighting comonent from an object to allow change 
    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the light component to allow change
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //this will change the value of the light intensity depending if powerLighting is true or false
        if(powerLighting == false)
        {
            //lerp = changes value from a to b
            _light.intensity = Mathf.Lerp(minBrightness, maxBrightness, brightTimer);
            brightTimer += _brightenRate * Time.deltaTime;
        }
        else if (powerLighting == true)
        {
            //changes value from b to a
            _light.intensity = Mathf.Lerp(maxBrightness, minBrightness, brightTimer);
            brightTimer += _brightenRate * Time.deltaTime;
        }
    }
}
