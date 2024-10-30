using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private float score;
    private bool isPlayerAlive = true;
    


    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            isPlayerAlive = false;
        }
        UpdateScoreText();
    }

    public void PlayerDied()
    {
        isPlayerAlive = false;
        Debug.Log("Player has died.");

    }

    // Reset the score and player state for a new game
    public void ResetGame()
    {
        score = 0; // Reset score
        isPlayerAlive = true; // Reset player state
        UpdateScoreText(); // Update score text display
        Debug.Log("Game has been reset.");
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score " + ((int)score).ToString();
    }

    private void Update()
    {
        // Get a reference to the GameManager
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

        // Update score if the player is alive
        if (isPlayerAlive)
        {
            score += 1 * Time.deltaTime;

            UpdateScoreText(); // Update the score display
           
        }
        else
        {
            // Call GameOver only if the player has died
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

}
