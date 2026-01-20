using UnityEngine;
using UnityEngine.UI;

public class Diffculty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        // Here you can add code to set the difficulty in your game manager or settings
        Debug.Log(gameObject.name + "was clicked");
        gameManager.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
