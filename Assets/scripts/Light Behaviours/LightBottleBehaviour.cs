using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBottleBehaviour : MonoBehaviour
{
    [Tooltip("this will grab two of the spot lighting")]
    [SerializeField]
    private Light _light1;
    bool _onCollision = false;
    public float timeLeft = 30.0f;
    public float timeLeftReset = 30.0f;
    public float a = 35;
    public float b = 50;
    public float t = 10;
    bool collided = false;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _light1 = GetComponentInChildren<Light>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    //this will tell what happens to an object when colliding
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LightingBottle"))
        {
            _light1.range = Mathf.Lerp(a, b, t);
            collided = true;
        }
    }

    private void Update()
    {
        if (collided == true)
            timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            _light1.range = Mathf.Lerp(b, a, t);
            timeLeft = timeLeftReset;
            collided = false;
        }
    }
}
