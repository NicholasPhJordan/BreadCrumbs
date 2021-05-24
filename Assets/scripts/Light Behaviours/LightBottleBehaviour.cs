using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBottleBehaviour : MonoBehaviour
{
    [Tooltip("this will grab two of the spot lighting")]
    [SerializeField]
    private Light _light1;
    //timer value and its reset that does not change
    public float timeLeft = 30.0f;
    public float timeLeftReset = 30.0f;
    //normal light range
    public float minbrightness = 35;
    //power up light range
    public float maxBrightness = 50;
    //the sets to tranform between ranges
    public float lightTimer = 10;
    private float _brightenRate = 0.5f;
    //this will help make sure timer does not go done when not needed
    private bool _collided = false;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //grabs the components needed 
        _light1 = GetComponentInChildren<Light>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    //this will tell what happens to an object when colliding
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LightingBottle"))
        {
            //this sets the lights range value to be bigger then normal
            _light1.range = Mathf.Lerp(minbrightness, maxBrightness, lightTimer);
            _collided = true;
        }
    }

    private void Update()
    {
        //this is a timer that will only only count down when collided = true
        if (_collided == true)
        {
            timeLeft -= Time.deltaTime;
        }

        //checks if the time value is 0
        if (timeLeft <= 0)
        {
            //this resets the value back
            timeLeft = timeLeftReset;
            _light1.range = Mathf.Lerp(maxBrightness, minbrightness, lightTimer);
            lightTimer += _brightenRate * Time.deltaTime;
            _collided = false;
        }
    }
}
