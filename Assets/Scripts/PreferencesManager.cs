using UnityEngine;

public static class PreferencesManager 
{
    public static float GetMusicVolume() 
    {
        // return the music volume, or 1f if it hasn't been set
        return PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    public static float GetMasterVolume() 
    {
        // return the master volume, or 1f if it hasn't been set
        return PlayerPrefs.GetFloat("MasterVolume", 1f); 
    }

    public static void SetMusicVolume(float soundLevel)
    {
        // set the music volume
        PlayerPrefs.SetFloat("MusicVolume", soundLevel);
    }

   public static void SetSoundVolume(float soundLevel)
   {
        // set the master volume
        PlayerPrefs.SetFloat("MasterVolume", soundLevel);
   }

}
