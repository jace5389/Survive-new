using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer masterMixer;

    // change the master volume
    public void ChangeSoundVolume(float soundLevel)
    {
        masterMixer.SetFloat("Master Volume", soundLevel);
    }

    // change the music volume
    public void ChangeMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("Music Volume", soundLevel);
    }

    // initialize the audio manager with the saved preferences
    public void Start()
    {
        masterMixer.SetFloat("Master Volume", PreferencesManager.GetMasterVolume());
        masterMixer.SetFloat("Music Volume", PreferencesManager.GetMusicVolume());
    }

    // ensure that there is only one instance of the audio manager
    private void Awake()
    {
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
