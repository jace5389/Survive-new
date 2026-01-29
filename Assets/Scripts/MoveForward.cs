using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 20.0f;
    private PlayerController playerControllerscript;
    public Vector3 axis;
   
    void Start()
    {
        // reference to PlayerController script
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

   
    void Update()
    {
        // move the object forward along the z axis
        if (playerControllerscript.gameOver == false)
        {
            transform.Translate(axis * speed * Time.deltaTime);
        }
    }
}