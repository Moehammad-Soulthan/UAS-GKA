using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseBtn;

    void Update()
    {
        if(GameIsPaused) {
            Pause();
        } else {
            Resume();
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        pauseBtn.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false; 
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        pauseBtn.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public void Quit() {
        GameIsPaused = false; 
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
}
