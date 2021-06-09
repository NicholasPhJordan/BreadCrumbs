using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerBehaviour : MonoBehaviour, IListener
{
    [SerializeField]
    private UnityEvent _actions;
    [SerializeField]
    private Event _event;
    [SerializeField]
    private GameObject _intendedSender;

    // Start is called before the first frame update
    void Start()
    {
        _event.AddListener(this);
    }

    public void Invoke(GameObject Sender)
    {
        if (_intendedSender == null || _intendedSender == Sender)
            _actions.Invoke();
    }
}
