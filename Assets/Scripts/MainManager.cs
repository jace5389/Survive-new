using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject titleScreen;
    public GameObject creditsScreen;
    public Button creditsButton;
    public Button backToSettings;
    public Slider musicSlider;
    public Slider masterSlider; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    public void OpenCredits()
    {
        // open the credits screen
        settingsScreen.gameObject.SetActive(false);
        creditsScreen.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        backToSettings.gameObject.SetActive(true);
    }

    public void BackToSettings()
    {
        // go back to the settings screen
        settingsScreen.gameObject.SetActive(true);
        creditsScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(true);
        backToSettings.gameObject.SetActive(false);
    }


    public void ChangeMusicVolume(float soundLevel)
    {
        // change the music volume
        AudioManager.instance.ChangeMusicVolume(soundLevel);
        PreferencesManager.SetMusicVolume(soundLevel);
    }


    public void ChangeSoundVolume(float soundLevel)
    {
        // change the sound volume
        AudioManager.instance.ChangeSoundVolume(soundLevel);
        PreferencesManager.SetSoundVolume(soundLevel);
    }
}
