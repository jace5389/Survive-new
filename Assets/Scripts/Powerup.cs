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

    // When the player collides with the powerup, activate the coin powerup effect and destroy the powerup object, then deactivate the coin powerup effect after 10 seconds
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.ActivateCoinPowerup();
            other.GetComponent<PlayerController>().ActivatePowerup();
            gameManager.Invoke("DeactivateCoinPowerup", 10f);
            Destroy(gameObject);
        }
    }
}
