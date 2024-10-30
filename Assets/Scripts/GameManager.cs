using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float cameraSpeed;
    public GameObject gameOverScreen;
    public AudioSource backgroundMusic;
    public GameObject buttonDown;
    public GameObject buttonUp;
    public GameObject pausePanel;
    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        CameraFollow();
    }

    public void CameraFollow()
    {
        //change camera x position constantly
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }

    public void RestartGame()
    {
        Debug.Log("Attempting to restart the game...");

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); // Hide the Game Over screen
        }

        if (backgroundMusic != null && backgroundMusic.clip != null)
        {
            backgroundMusic.Play();
            Debug.Log("Background music started.");
        }
        else
        {
            Debug.LogWarning("Background music or clip is missing.");
        }

        // Reset the ScoreManager
        ScoreManager scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ResetGame();
        }
        else
        {
            Debug.LogWarning("ScoreManager not found.");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        Time.timeScale = 1; // Ensure time is set to normal
        Debug.Log("Restarting game...");
    }


    public void GameOver()
    {
        Debug.Log("GameOver function called");
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            buttonDown.SetActive(false);
            buttonUp.SetActive(false);

        }
        else
        {
            Debug.LogError("Game Over panel is not assigned!");
        }
        
        
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
            Debug.Log("Background music stopped");
        }
        
        
    }



    //public void PauseGame()
    //{
    //    isPaused = !isPaused;
    //    if (isPaused)
    //    {
    //        Time.timeScale = 0;
    //        pausePanel.SetActive(true);
    //        backgroundMusic.Stop();
    //        Debug.Log("Game Paused");
    //    }
    //    else
    //    {
    //        Time.timeScale = 1;
    //        pausePanel.SetActive(false);
    //        backgroundMusic.Play();
    //        Debug.Log("Game resumed");
    //    }
    //}


    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);

            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
                Debug.Log("Background music stopped.");
            }
            else
            {
                Debug.LogWarning("Background music reference is missing.");
            }

            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);

            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
                Debug.Log("Background music resumed.");
            }
            else
            {
                Debug.LogWarning("Background music reference is missing.");
            }

            Debug.Log("Game resumed");
        }
    }

}
