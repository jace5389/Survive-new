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

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the GameManager and update the score
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.UpdateScore(value);
            Destroy(gameObject);
        }
    }
}