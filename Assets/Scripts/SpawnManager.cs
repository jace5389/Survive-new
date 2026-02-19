using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefab;
    public GameObject[] lifePrefab;
    public GameObject[] powerupPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private float CoinStartDelay = 2.5f;
    private float CoinRepeatRate = 2.3f; 
    private float LifeStartDelay = 10.9f;
    private float LifeRepeatRate = 10.1f; 
    private float PowerupStartDelay = 7.5f;
    private float PowerupRepeatRate = 7.45f;
    private PlayerController playerControllerscript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // find the PlayerController script to check for game over state
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnCoin", CoinStartDelay, CoinRepeatRate);
        InvokeRepeating("SpawnLife", LifeStartDelay, LifeRepeatRate);
        InvokeRepeating("SpawnPowerup", PowerupStartDelay, PowerupRepeatRate);
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        // spawn obstacles at random x positions
        if (playerControllerscript.gameOver == false)
        {
            spawnPos = new Vector3(Random.Range(16.66f, 17.66f),1.0f, 0);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }

    void SpawnCoin()
    {
        // spawn coins at random x positions
        if (playerControllerscript.gameOver == false)
        {
            
            spawnPos = new Vector3(Random.Range(16.66f, 17.66f),1.0f, 0);   
            int coinIndex = Random.Range(0, coinPrefab.Length);
            Instantiate(coinPrefab[coinIndex], spawnPos, coinPrefab[coinIndex].transform.rotation);
        }
    }

    void SpawnLife()
    {
        // spawn life at random x positions
        if (playerControllerscript.gameOver == false)
        {
            
            spawnPos = new Vector3(Random.Range(16.66f, 17.66f),1.0f, 0);
            int lifeIndex = Random.Range(0, lifePrefab.Length);
            Instantiate(lifePrefab[lifeIndex], spawnPos, lifePrefab[lifeIndex].transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        // spawn powerup at random x positions
        if (playerControllerscript.gameOver == false)
        {
            
            spawnPos = new Vector3(Random.Range(16.66f, 17.66f),1.0f, 0);
            int powerupIndex = Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[powerupIndex], spawnPos, powerupPrefab[powerupIndex].transform.rotation);
        }
    }
}
