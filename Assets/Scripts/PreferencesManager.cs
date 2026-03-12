using UnityEngine;

public static class PreferencesManager 
{
    // return the music volume, or 1f if it hasn't been set
    public static float GetMusicVolume() 
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    // return the master volume, or 1f if it hasn't been set
    public static float GetMasterVolume() 
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1f); 
    }

    // set the music volume
    public static void SetMusicVolume(float soundLevel)
    {
        PlayerPrefs.SetFloat("MusicVolume", soundLevel);
    }

    // set the master volume
    public static void SetSoundVolume(float soundLevel)
    {
        PlayerPrefs.SetFloat("MasterVolume", soundLevel);
    }
}
