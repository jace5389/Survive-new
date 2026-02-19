using UnityEngine;
using UnityEngine.UI;

public class Diffculty : MonoBehaviour
{
    private Button button;
    public GameManager gameManager;
    public int difficulty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the button component
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        // set the difficulty and start the game
        Debug.Log(gameObject.name + "was clicked");
        gameManager.StartGame(difficulty);
    }
}
