using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    private GameObject _gameOverUI;
    public static bool GamePaused = false;
    public Animator transition;

    //changes scene with the fade transition =
    public IEnumerator LoadLevel(int levelIndex)
    {
        //triggers the transition
        transition.SetTrigger("Start");
        //waits for 1 second
        yield return new WaitForSeconds(1);
        //loads the given scene
        SceneManager.LoadScene(levelIndex);
    }

    //Update is called once per frame
    private void Update()
    {
        //only detect esc if in game scene
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        //when player dies, go to GameOver scene
        if (GameManager.gameOver)
        {
            StartCoroutine(LoadLevel(2));
            GameManager.SetGameOver = false;
        }
    }

    //loads the next scene for the Start button
    public void PlayGame()
    {
        StartCoroutine(
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Quites and closes the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Unpauses game and closes UI
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    //Pauses game and opens UI
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    //Brings the player back to the title screen
    public void QuitToTitle()
    {
        Time.timeScale = 1f;
        GamePaused = false;
        StartCoroutine(LoadLevel(0));
    }

    //Brings the player back to the Game Scene 
    public void Restart()
    {
        StartCoroutine(LoadLevel(1));
    }
}
