using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [Tooltip("The object the enemy will be seeking towards.")]
    [SerializeField]
    private GameObject _target;
    private GameObject _targetInUse;
    private NavMeshAgent _agent;

    [Tooltip("The usual rate the enemy shall move at")]
    [SerializeField]
    private float _runSpeed;
    [Tooltip("The rate at which the speed is decreased")]
    [SerializeField]
    private float _speedModifier;

    [Tooltip("The timer until the enemy starts hunting the player")]
    [SerializeField]
    private float _startTimer;
    [Tooltip("The timer until the enemy starts sprinting again after slowing down")]
    [SerializeField]
    private float _trackingTimer;
    private float _timer;

    private Vector3 _homePosition;
    private Vector3 _pursuitDestination;
    private Vector3 _targetLastPosition;
    private bool _isCuttingOff;

    private int randomNumber;

    public GameObject TargetInUse
    {
        //The property referencing the enemy's target

        get
        {
            return _targetInUse;
        }
        set
        {
            _targetInUse = value;
        }
    }

    public Vector3 EnemyPosition
    {
        //The property referencing the enemy's position

        get
        {
            return _agent.transform.position;
        }
        set
        {
            _agent.transform.position = _homePosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        //Get a reference to the navmesh agent
        _agent = GetComponent<NavMeshAgent>();

        //Set the enemy's home position for future reference
        _homePosition = _agent.transform.position;
        //Start the enemy trying to cut off the player
        _isCuttingOff = true;

        //Set the speed
        _agent.speed = _runSpeed;
        //Set the timer
        _timer = _trackingTimer;

        //Quick randomization of starter to add to the horror elements
        StartingTimerRandomizer();
        //Begin dropping waypoints to the player every 1.5 seconds
        StartCoroutine(PastPositionUpdate());
    }

    private void FixedUpdate()
    {
        //If a target hasn't been set return
        if (!_targetInUse)
        {
            _startTimer -= 1;

            if (_startTimer == 0)
                _targetInUse = _target;

            return;
        }

        //Determine the speed and timing of the enemy's movements for hopefully balanced gameplay
        SpeedAndTiming();

        if(!_isCuttingOff)
        {
            //Set the target's location as the target destination
            _agent.SetDestination(_targetInUse.transform.position);
        }
        else
        {
            //Move the enemy to cut off the player
            PursuitCutOff();
        }
        
    }

    private void SpeedAndTiming()
    {
        //If the target is within a radius from the target, and its speed is greater than 1
        if (_agent.remainingDistance < 5.5 && _agent.remainingDistance > 0.2 && _agent.speed > 1.5)
        {
            //Make the enemy chase directly
            if (_isCuttingOff)
                _isCuttingOff = false;

            //reduce speed by the speed modifier
            _agent.speed -= _speedModifier;
            //Reset the timer in case it was modified
            _timer = _trackingTimer;


            //If the agent's speed somehow drops below 1, catch it
            if (_agent.speed < 1.5)
                _agent.speed = 1.5f;
        }
        //If the agent is outside the radius while still having a decreased speed
        else if (_agent.remainingDistance > 5.5 && _agent.speed < _runSpeed)
        {
            //Make the enemy start the pursuit
            if (!_isCuttingOff)
                _isCuttingOff = true;

            //Tick down the timer
            _timer -= 0.1f;

            //If the timer hits 0
            if (_timer <= 0)
            {
                //Decrease the run cooldown
                if (_trackingTimer > 0)
                    _trackingTimer -= 1;

                //Reset the speed to usual
                _agent.speed = _runSpeed;
                //Reset the timer for next time
                _timer = _trackingTimer;
            }
        }
    }

    private void PursuitCutOff()
    {
        //Take the velocity and use it to predict where the target is moving
        _pursuitDestination = _targetInUse.transform.position - _targetLastPosition;

        //Set the enemy's target location to the predicted next location of the target
        _agent.SetDestination(_pursuitDestination);
    }

    private IEnumerator PastPositionUpdate()
    {
        //Drop a waypoint of the target's location
        _targetLastPosition = _targetInUse.transform.position;
        //Wait 1.5 seconds to drop a new waypoint
        yield return new WaitForSeconds(1.5f);
    }

    private int StartingTimerRandomizer()
    {
        //Randomize a number within the range
        randomNumber = Random.Range(0, 5);

        //Modify the time until the enemy starts hunting the player slightly
        switch(randomNumber)
        {
            case 0:
                _startTimer -= 150;
                break;
            case 1:
                _startTimer -= 100;
                break;
            case 2:
                _startTimer -= 50;
                break;
            case 3:
                _startTimer += 0;
                break;
            case 4:
                _startTimer += 50;
                break;
            case 5:
                _startTimer += 100;
                break;
        }

        return 1;
    }
}
