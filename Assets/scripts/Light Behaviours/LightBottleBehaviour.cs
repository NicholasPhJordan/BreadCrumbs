using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBottleBehaviour : MonoBehaviour
{
    [Tooltip("this will grab two of the spot lighting")]
    [SerializeField]
    private Light _light1;
    private Light _light2;

    // Start is called before the first frame update
    void Start()
    {
        _light1 = GetComponent<Light>();
        _light2 = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
