using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenuUI;
    public static bool GamePaused = false;
    public Animator transition;

    //loads the next scene for the Start button
    public void PlayGame()
    {
        StartCoroutine(
            LoadLevel(
                SceneManager.GetActiveScene().buildIndex + 1));
        
    }

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

    //Quites and closes the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Update is called once per frame
    private void Update()
    {
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
}
