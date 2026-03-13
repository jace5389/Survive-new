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
    }
}
