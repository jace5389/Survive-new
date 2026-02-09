using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI titleScreenText;
    public bool isGameActive;
    public Button restartButton;
    public Button playButton;
    public Button settingsButton;
    public Button backButton;
    public Button exitButton;
    private int score;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject settingsScreen;
    private float spawnRate = 1.0f;
    public int coinValue;
    public bool coinPowerup;
    public PlayerController playerController;
    public GameObject[] lives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize game state
        score = 0;
        isGameActive = true;
        UpdateScore(0);
    }

    public void GameOver()
    {
        // handle game over state
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        // update the player's score
        if (coinPowerup)
        {
            scoreToAdd *= 3;
        }
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        
    }

    public void RestartGame()
    {
        // restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame() 
    {
        // exit the application
        Debug.Log("Exiting Game...");
        Application.Quit();
        exitButton.gameObject.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        // start the game with the specified difficulty
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    public void PlayGame()
    {
        // load the main game scene
        SceneManager.LoadScene("MainGame"); 
        playButton.gameObject.SetActive(false);
    }
    

    public void OpenSettings()
    {
        // open the settings screen
        settingsScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
    }

    public void BackToMain()
    {
        // return to the main title screen
        settingsScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void ShowTitleScreen()
    {
        // show the title screen
        titleScreen.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void ActivateCoinPowerup()
    {
        // activate coin power-up
        coinPowerup = true;
    }

    public void DeactivateCoinPowerup()
    {
        // deactivate coin power-up
        coinPowerup = false;
    }

    public void UpdateLives(int livesToAdd)
    {
        // update the player's lives
        if(playerController.health <= 3)
        {
            playerController.health += livesToAdd;
        }
        else if (playerController.health > 3)
        {
            playerController.health = 3;
        }


        for (int i = 0; i < lives.Length; i++)
        {
            if (i < playerController.health)
            {
                lives[i].SetActive(true);
            }
            else
            {
                lives[i].SetActive(false);
            }
        }   
    }
}
