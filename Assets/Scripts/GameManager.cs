using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static List<CollectibleBehaviour> collected = new List<CollectibleBehaviour>();
    [SerializeField]
    private Event _onCollected;
    [Tooltip("The amount the player must collect to reset Collectibles")]
    [SerializeField]
    private int _collectAmount;
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private Text HighScoreText;
    public static bool gameOver = false;
    private static int _playerScore;
    private static int _highScore;

    public static int PlayerScore
    {
        get { return _playerScore; }
    }

    public static bool SetGameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_highScore < _playerScore)
            _highScore = _playerScore;
        _playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected.Count >= _collectAmount)
        {
            _onCollected?.Raise(gameObject);
            collected.Clear();
        }

        HighScoreText.text = "High Score " + _highScore;
        ScoreText.text = "Score " + _playerScore;
    }

    //adds a collectible to the collected list and updates score
    public static void AddCollectable(CollectibleBehaviour collectible)
    {
        collected.Add(collectible);
        _playerScore += collectible._scoreAmount;
    }

}
