using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void LoadHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

        public void OpenOptions()
    {
        Debug.Log("Options button clicked - Implement options menu functionality here.");
      
    }

    public void ExitGame()
    {
        Debug.Log("Exit button clicked - If this were a build, the application would quit.");
       
        Application.Quit();
    }
}

