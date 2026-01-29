using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    // Detect collision with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.UpdateScore(value);
            Destroy(gameObject);
        }
    }
}
