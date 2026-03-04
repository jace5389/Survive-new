using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;
    public TextMeshProUGUI pauseText;
    public bool isGameActive;
    public Button restartButton;
    public Button playButton;
    public Button settingsButton;
    public Button backButton;
    public Button exitButton;
    public Button pauseButton;
    public Button continueButton;
    public Button quitButton;
    private int score;
    public int highScore;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    private float spawnRate = 1.0f;
    public int coinValue;
    public bool coinPowerup;
    public PlayerController playerController;
    public GameObject[] lives;

    void Start()
    {
        // initialize game state
        score = 0;
        isGameActive = true;
        UpdateScore(0);
        LoadPlayer();
    }

    public void GameOver()
    {
        // handle game over state
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        highScoreText.text = "Final Score: " + score;
        if (score > highScore)
        {
          highScore = score;
          newHighScoreText.gameObject.SetActive(true);
          SavePlayer();
        }
        newHighScoreText.text = "New High Score: " + highScore;
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
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame(int difficulty)
    {
        // set the difficulty and start the game
        spawnRate /= difficulty;
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
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

    public void TitleScreen()
    {
        // show the title screen
        titleScreen.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(false);
        settingsScreen.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        // pause the game
        pauseScreen.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0f;
    }

    public void PauseScreen()
    {
        // show the pause screen
        pauseScreen.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        // continue the game
        isGameActive = true;
        Time.timeScale = 1f;
        pauseScreen.gameObject.SetActive(false);
    }

    public void QuitToMain()
    {
        // quit to the main title screen
        Time.timeScale = 1f;
        isGameActive = false;
        SceneManager.LoadScene("MainMenu");
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

    public void SavePlayer ()
    {
        // save the player's data
        PlayerData playerData = new PlayerData(highScore);
        SaveSystem.SavePlayer(playerData);
    }   

    public void LoadPlayer ()
    {
        // load the player's data
        PlayerData playerData = SaveSystem.LoadPlayer();
        if (playerData != null)
        {
           highScore = playerData.score;
        }
    }

    public void UpdateLives(int livesToAdd)
    {
        // update the player's lives
        if (playerController.health <= 3)
        {
            playerController.health += livesToAdd;
        }
        else if (playerController.health > 3)
        {
            playerController.health = 3;
        }

        // update the UI to reflect the current number of lives
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
