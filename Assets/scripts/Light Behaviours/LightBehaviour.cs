using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [Tooltip("this will change from false to true if the lighting power up is false")]
    [SerializeField]
    private bool powerLighting;

    public float a;
    public float b;
    public float t;

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
            _light.intensity = Mathf.Lerp(a, b, t);
        }
        else if (powerLighting == true)
        {
            //changes value from b to a
            _light.intensity = Mathf.Lerp(b, a, t);
        }
    }
}
