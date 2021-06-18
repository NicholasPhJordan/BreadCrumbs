using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _highScoreText;
    [SerializeField]
    private Text _roundText;
    private static int _playerScore;
    private static int _highScore;
    public static int _round;

    // Start is called before the first frame update
    void Start()
    {
        if (_highScore < _playerScore)
            _highScore = _playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        _playerScore = GameManager.PlayerScore;
        _round = GameManager.Round;

        _scoreText.text = "Score " + _playerScore;
        _highScoreText.text = "High Score      " + _highScore;
        _roundText.text = "Round: " + _round;
    }
}
