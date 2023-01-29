using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int playerHighScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource audioSource;
    public AudioClip addScoreSFX;
    public AudioClip gameOverSFX;
    private bool gameOverSFXHasPlayed = false;

    private void Start()
    {
        playerHighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = playerHighScore.ToString();
    }

    private void saveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", playerScore);
        playerHighScore = playerScore;
        highScoreText.text = playerHighScore.ToString();
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > playerHighScore)
        {
            saveHighScore();
        }

        audioSource.PlayOneShot(addScoreSFX, 0.7f);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (!gameOverSFXHasPlayed)
        {
            audioSource.PlayOneShot(gameOverSFX, 0.7f);
            gameOverSFXHasPlayed = true;
        }    
    }
}
