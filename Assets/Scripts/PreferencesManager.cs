using UnityEngine;

public static class PreferencesManager 
{
    public static float GetMusicVolume() 
    { 
        return PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    public static float GetMasterVolume() 
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1f); 
    }

    public static void SetMusicVolume(float soundLevel)
    {
         PlayerPrefs.SetFloat("MusicVolume", soundLevel);
    }

   public static void SetSoundVolume(float soundLevel)
   {        
        PlayerPrefs.SetFloat("MasterVolume", soundLevel);
   }

}
