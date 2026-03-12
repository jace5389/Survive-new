using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

    }

    // When the player collides with the coin object, update the score and destroy the coin object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.UpdateScore(value);
            Destroy(gameObject);
        }
    }
}