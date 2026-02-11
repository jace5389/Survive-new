using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        // load the main game scene
        SceneManager.LoadScene("GameScene");
        
    }


    public void OpenSettings()
    {
        // open the settings screen
        settingsScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    public void TitleScreen()
    {
        // show the title screen
        titleScreen.gameObject.SetActive(true);
        settingsScreen.gameObject.SetActive(false);
    }
}
