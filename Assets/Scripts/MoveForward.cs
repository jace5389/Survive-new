using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20.0f;
    private PlayerController playerControllerscript;
    public Vector3 axis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerscript.gameOver == false)
        {
            transform.Translate(axis * speed * Time.deltaTime);
        }
    }
}