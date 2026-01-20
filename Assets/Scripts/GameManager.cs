using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;
    public Button restartButton;
    private int score;
    public GameObject titleScreen;
    private float spawnRate = 1.0f;
    private GameManager gameManager;
    public int pointValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        score = 0;
        isGameActive = true;
        UpdateScore(0);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.UpdateScore(pointValue);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        UpdateScore(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
