using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerData { 

    public int score;
    
    public PlayerData(int score)
    {
        // initialize the player's data
        this.score = score;
    }
}

