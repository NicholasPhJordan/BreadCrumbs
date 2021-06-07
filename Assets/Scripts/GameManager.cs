﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static List<CollectibleBehaviour> collected = new List<CollectibleBehaviour>();
    [SerializeField]
    private Event _onCollected;
    [Tooltip("The amount the player must collect to reset Collectibles")]
    [SerializeField]
    private int _collectAmount;
    private static int _playerScore;

    public static int PlayerScore
    {
        get { return _playerScore; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected.Count >= _collectAmount)
        {
            _onCollected?.Raise(gameObject);
            collected.Clear();
        }
    }

    public static void AddCollectable(CollectibleBehaviour collectible)
    {
        collected.Add(collectible);
        _playerScore += collectible._scoreAmount;
        Debug.Log(collected.Count);
    }

}