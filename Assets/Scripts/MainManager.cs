using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public TextMeshProUGUI musicVolumeText;
    public TextMeshProUGUI masterVolumeText;  
    public GameObject settingsScreen;
    public GameObject titleScreen;
    public GameObject creditsScreen;
    public Button creditsButton;
    public Button backToSettings;
    public Slider musicSlider;
    public Slider masterSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (masterSlider != null)
        {
            masterSlider.value = PreferencesManager.GetMasterVolume();
        }

        if (musicSlider != null)
        {
            musicSlider.value = PreferencesManager.GetMusicVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load the game scene when the player clicks the play button
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quit the application when the player clicks the quit button
    public void OpenSettings()
    {
        settingsScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    // Go back to the title screen when the player clicks the back button
    public void TitleScreen()
    {
        titleScreen.gameObject.SetActive(true);
        settingsScreen.gameObject.SetActive(false);
    }

    // Open the credits screen when the player clicks the credits button
    public void OpenCredits()
    {
        settingsScreen.gameObject.SetActive(false);
        creditsScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        backToSettings.gameObject.SetActive(true);
    }

    // Go back to the settings screen when the player clicks the back button on the credits screen
    public void BackToSettings()
    {
        settingsScreen.gameObject.SetActive(true);
        creditsScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(true);
        backToSettings.gameObject.SetActive(false);
    }

    // Change the master volume when the player adjusts the master volume slider
    public void ChangeMusicVolume(float soundLevel)
    {
        AudioManager.instance.ChangeMusicVolume(soundLevel);
        PreferencesManager.SetMusicVolume(soundLevel);
    }

    // Change the sound volume when the player adjusts the sound volume slider
    public void ChangeSoundVolume(float soundLevel)
    {
        AudioManager.instance.ChangeSoundVolume(soundLevel);
        PreferencesManager.SetSoundVolume(soundLevel);
    }

    public void SetDifficulty(int diff)
    {
        GameManager.spawnRate = diff;
    }
}
