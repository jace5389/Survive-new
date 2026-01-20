using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.MeshOperations;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool hasCollectable;
    public bool gameOver = false;
    public GameObject collectableIndicator;
    public int score = 0;
    float horizontalInput;
    bool hasJumped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        if (hasJumped && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

        }

        

        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        //collectableIndicator.transform.position = transform.position + new Vector3(0, 2, 0);
    }

    // collision for ground and obstacles
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }

    // trigger for collectables
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            hasCollectable = true;
            Destroy(other.gameObject);
            score++;
            //StartCoroutine(CollectableCountdownRoutine());
            //collectableIndicator.SetActive(true);
        }
    }

    // coroutine for collectable countdown
    IEnumerator CollectableCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasCollectable = false;
        collectableIndicator.SetActive(false);
    }

    // move input action
    public void OnMove(InputValue inputValue)
    {
        horizontalInput = inputValue.Get<Vector2>().x;
    }

    // jump input action
    public void OnJump(InputValue inputValue)
    {
        hasJumped = inputValue.isPressed;
    }

}    