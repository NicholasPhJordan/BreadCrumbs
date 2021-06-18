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
        _agent = GetComponent<NavMeshAgent>();

        _homePosition = _agent.transform.position;
        _isCuttingOff = true;
        _agent.speed = _runSpeed;
        _timer = _trackingTimer;

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

        SpeedAndTiming();

        if(!_isCuttingOff)
        {
            //Set the target's destination for the navmesh
            _agent.SetDestination(_targetInUse.transform.position);
        }
        else
        {
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

        _agent.SetDestination(_pursuitDestination);
    }

    private IEnumerator PastPositionUpdate()
    {
        _targetLastPosition = _targetInUse.transform.position;
        yield return new WaitForSeconds(1.5f);
    }

    private int StartingTimerRandomizer()
    {
        randomNumber = Random.Range(0, 5);



        return 1;
    }
}
