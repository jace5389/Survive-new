using UnityEngine;
using UnityEngine.UI;

public class Diffculty : MonoBehaviour
{
    private Button button;
    public GameManager gameManager;
    public int difficulty;

    // get the button component
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // set the difficulty and start the game when the button is clicked
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was clicked");
        gameManager.StartGame(difficulty);
    }
}
