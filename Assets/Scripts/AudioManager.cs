using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer masterMixer;
   
    public void ChangeSoundVolume(float soundLevel)
    {
        // change the master volume
        masterMixer.SetFloat("Master Volume", soundLevel);
    }

    public void ChangeMusicVolume(float soundLevel)
    {
        // change the music volume
        masterMixer.SetFloat("Music Volume", soundLevel);
    }

    public void Start()
    {
        // set the master and music volume to the saved preferences
        masterMixer.SetFloat("Master Volume", PreferencesManager.GetMasterVolume());
        masterMixer.SetFloat("Music Volume", PreferencesManager.GetMusicVolume());
    }

    private void Awake()
    {
        // ensure that there is only one instance of the AudioManager and that it persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
