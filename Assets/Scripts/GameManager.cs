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
    public Button exitButton;
    public Button pauseButton;
    public Button continueButton;
    public Button quitButton;
    private int score;
    public int highScore;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject titleScreen;
    public static float spawnRate = 1.0f;
    public int coinValue;
    public bool coinPowerup;
    public PlayerController playerController;
    public GameObject[] lives;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartGame();
        UpdateScore(0);
        LoadPlayer();
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        highScoreText.text = " Score: " + score;
        if (score > highScore)
        {
          highScore = score;
          newHighScoreText.gameObject.SetActive(true);
          SavePlayer();
        }
        newHighScoreText.text = " High Score: " + highScore;
    }

    // method to update the player's score and update the score text UI
    public void UpdateScore(int scoreToAdd)
    {
        if (coinPowerup)
        {
            scoreToAdd *= 3;
        }
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // method to restart the game by reloading the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // method to exit the game and return to the main menu
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }

    // method to start the game with a specified difficulty level, which adjusts the spawn rate of obstacles and power-ups
    public void StartGame()
    {
        isGameActive = true;
    }

    // method to pause the game, which activates the pause screen UI and stops the game's time scale
    public void PauseGame()
    {
        pauseScreen.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0f;
    }

    // method to display the pause screen UI when the game is paused
    public void PauseScreen()
    {
        pauseScreen.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    // method to continue the game from the paused state
    public void ContinueGame()
    {
        isGameActive = true;
        Time.timeScale = 1f;
        pauseScreen.gameObject.SetActive(false);
    }

    // method to quit the current game and return to the main menu
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        isGameActive = false;
        SceneManager.LoadScene("MainMenu");
    }

    // method to activate the coin power-up effect, which triples the score gained from collecting coins
    public void ActivateCoinPowerup()
    {
        coinPowerup = true;
    }

    // method to deactivate the coin power-up effect after a certain duration
    public void DeactivateCoinPowerup()
    {
        coinPowerup = false;
    }

    // method to save the player's data, including the high score, using the SaveSystem class
    public void SavePlayer ()
    {
        PlayerData playerData = new PlayerData(highScore);
        SaveSystem.SavePlayer(playerData);
    }

    // method to load the player's data and update the high score
    public void LoadPlayer ()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();
        if (playerData != null)
        {
           highScore = playerData.score;
        }
    }

    // method to update the player's lives and update the UI to reflect the current number of lives
    public void UpdateLives(int livesToAdd)
    {
        if (playerController.health <= 3)
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
