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
    private NavMeshAgent _agent;
    [Tooltip("The usual rate the enemy shall move at")]
    [SerializeField]
    private float _runSpeed;
    [Tooltip("The rate at which the speed is decreased")]
    [SerializeField]
    private float _speedModifier;
    [Tooltip("The timer until the enemy starts sprinting again after slowing down")]
    [SerializeField]
    private float _trackingTimer;
    private float _timer;
    private int _case;

    public GameObject Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();

        _agent.speed = _runSpeed;
        _timer = _trackingTimer;
    }

    private void FixedUpdate()
    {
        //If a target hasn't been set return
        if (!_target)
            return;

        //If the target is within a radius from the target, and its speed is greater than 1
        if (_agent.remainingDistance < 4 && _agent.remainingDistance > 1.5 && _agent.speed > 1)
        {
            //reduce speed by the speed modifier
            _agent.speed -= _speedModifier;
            //Reset the timer in case it was modified
            _timer = _trackingTimer;

            //Decrease the run cooldown the more the enemy gets close to the player
            if (_agent.remainingDistance < 3)
            {
                if (_trackingTimer >= 0)
                    _trackingTimer -= 1;
            }

            //If the agent's speed somehow drops below 1, catch it
            if (_agent.speed < 1)
                _agent.speed = 1;
        }
        //If the agent is outside the radius while still having a decreased speed
        else if (_agent.remainingDistance > 4 && _agent.speed < _runSpeed)
        {
            //Tick down the timer
            _timer -= 0.1f;

            //If the timer hits 0
            if (_timer <= 0)
            {
                //Reset the speed to usual
                _agent.speed = _runSpeed;
                //Reset the timer for next time
                _timer = _trackingTimer;
            }
        }

        //Set the target's destination for the navmesh
        _agent.SetDestination(_target.transform.position);
    }
}
