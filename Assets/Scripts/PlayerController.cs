using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public int score = 0;
    public int health = 3;
    float horizontalInput;
    bool hasJumped = false;
    public GameManager gameManager;
   


    void Start()
    {
        // get the rigidbody component
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    
    void Update()
    {
        // jump mechanic
        if (hasJumped && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // collision for ground and obstacles
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            health--;
            if (health <= 0)
            {
                gameOver = true;
                gameManager.GameOver();
                Debug.Log("Game Over!");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
    }

    // move input action
    public void OnMove(InputValue inputValue)
    {
        horizontalInput = inputValue.Get<Vector2>().x;
    }

    public void MoveInput(Vector2 vaule)
    {
        horizontalInput = vaule.x;
    }

    // jump input action
    public void OnJump(InputValue inputValue)
    {
        hasJumped = inputValue.isPressed;
    }

    public void JumpInput(bool value)
    {
        hasJumped = value;
    }
}    