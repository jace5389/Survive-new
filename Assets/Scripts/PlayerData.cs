using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PlayerData 
{ 
    public int score;

    // constructor to initialize the player's score
    public PlayerData(int score)
    {
        this.score = score;
    }
}

