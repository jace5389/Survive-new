using UnityEngine;

public class Powerup : MonoBehaviour
{
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
            // Activate the coin powerup in the GameManager
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.ActivateCoinPowerup();
            gameManager.Invoke("DeactivateCoinPowerup", 10f);
            Destroy(gameObject);
        }
    }
}
