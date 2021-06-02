using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollectedListener : MonoBehaviour
{
    [SerializeField]
    private Event _onCollected;
    [SerializeField]
    private int collectCount;

    // Update is called once per frame
    void Update()
    {
        bool doReset = ResetCount(GameManager.collected.Count);

        if (doReset)
            _onCollected?.Raise(gameObject);
    }

    bool ResetCount(int collected)
    {
        if (collected % collectCount == 0)
        {
            return true;
        } 
        else
        {
            return false;
        }
        
    }
}
