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
        masterMixer.SetFloat("Master Volume", soundLevel);
    }

    public void ChangeMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("Music Volume", soundLevel);
    }

    public void Start()
    {
        masterMixer.SetFloat("Master Volume", PreferencesManager.GetMasterVolume());
        masterMixer.SetFloat("Music Volume", PreferencesManager.GetMusicVolume());
    }

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
