using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }
    public AudioMixer masterMixer;
    public Slider musicSlider, masterSlider;
    
    // Ensure that only one instance of AudioManager exists and persists across scenes
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Methods to change the volume of sound and music using logarithmic scaling for better user experience
    public void ChangeSoundVolume(float volume)
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void ChangeMusicVolume(float volume)
    {
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }


    // Initialize the AudioMixer reference
    void Start()
    {
        masterMixer = GetComponent<AudioMixer>();
    }
}
