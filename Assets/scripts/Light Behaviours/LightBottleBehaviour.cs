using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBottleBehaviour : MonoBehaviour
{
    [Tooltip("this will grab two of the spot lighting")]
    [SerializeField]
    private Light _light1;
    bool _onCollision = false;
    float timeLeft = 30.0f;
    float a = 35;
    float b = 50;
    float t = 1;

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
            LightChange();
        }
    }

    //this is so that it will 
    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.1f;
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }

    //this is the function for light to change
    void LightChange()
    {
        _light1.range = Mathf.Lerp(a, b, t);
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            _light1.range = Mathf.Lerp(b, a, t);
        }
    }
}
