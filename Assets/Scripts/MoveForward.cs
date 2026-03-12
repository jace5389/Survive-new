using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20.0f;
    private PlayerController playerControllerscript;
    public Vector3 axis;

    // find the PlayerController script to check for game over state
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // move the object forward along the z axis
    void Update()
    { 
        if (playerControllerscript.gameOver == false)
        {
            transform.Translate(axis * speed * Time.deltaTime);
        }
    }
}