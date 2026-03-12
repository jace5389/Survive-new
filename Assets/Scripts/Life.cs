using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the player collides with the life object, increase the player's lives by 1 and destroy the life object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.UpdateLives(1);
            Destroy(gameObject);
        }
    }
}
