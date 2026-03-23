using System.Collections;
using TMPro;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    private Coroutine shieldCoroutine;
    private Coroutine powerupCoroutine;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI powerupText;
    public GameObject shieldVisual;
    public Animator anim;
    public GameManager gameManager;
    public PlayerState playerState;
    public float jumpForce;
    public float gravityModifier;
    public float shieldDuration = 10f;
    public float powerupDuration = 10f;
    public float shieldTimer;
    public float powerupTimer;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool hasPowerup = false;
    public bool hasShield = false;
    public int health = 3;
    float horizontalInput;
    bool hasJumped = false;
    internal static object instance;
   
    // reference to animator and game manager
    public void Awake()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // initialize player rigidbody and modify gravity
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // handle player movement and jumping based on input and update player state
    void Update()
    {
        if (hasJumped && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            hasJumped = false;
            SetPlayerState(PlayerState.Jump);
        }
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // detect collision with ground to reset jump and update player state
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            SetPlayerState(PlayerState.Run);
        }
    }

    // detect collision with obstacles to handle health, shield, and game over logic
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Obstacle"))
        {
            playerRb.linearVelocity = new Vector3(0, playerRb.linearVelocity.y, 0);
            if (hasShield)
            {
                Destroy(other.gameObject);
                return;
            }
            else
            {
                gameManager.UpdateLives(-1);
                if (health <= 0)
                {
                    gameOver = true;
                    SetPlayerState(PlayerState.Death);
                    gameManager.Invoke("GameOver", 2f);
                    Debug.Log("Game Over!");
                }
            }
        }
    }

    // method to activate shield powerup
    public void ActivateShield()
    {
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }
        shieldCoroutine = StartCoroutine(ShieldTimer());
    }

    // coroutine to handle shield powerup duration and visual effects
    IEnumerator ShieldTimer()
    {
        hasShield = true;
        if (shieldVisual != null)
        {
            shieldVisual.SetActive(true);
        }
        
        shieldTimer = shieldDuration;
        Debug.Log("Shield ON");
        while (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = "Shield: " + Mathf.CeilToInt(shieldTimer) + "s";
            }
            yield return null;
        }

        hasShield = false;
        if (shieldVisual != null)
        { 
            shieldVisual.SetActive(false); 
        }

        if (timerText != null)
        {
            timerText.text = "";
        }
        Debug.Log("Shield OFF");
    }

    // method to activate coin powerup
    public void ActivatePowerup()
    {
        if (powerupCoroutine != null)
        {
            StopCoroutine(powerupCoroutine);
        }
        powerupCoroutine = StartCoroutine(PowerupTimer());
    }

    // coroutine to handle coin powerup duration and UI updates
    IEnumerator PowerupTimer()
    {
        hasPowerup = true;
        powerupTimer = powerupDuration;
        Debug.Log("Powerup ON");
        while (powerupTimer > 0)
        {
            powerupTimer -= Time.deltaTime;
            if (powerupText != null)
            {
                powerupText.text = "Powerup: " + Mathf.CeilToInt(powerupTimer) + "s";
            }
            yield return null;
        }

        hasPowerup = false;
        if (powerupText != null)
        {
            powerupText.text = "";
        }
        Debug.Log("Powerup OFF");
    }

    // player states
    public enum PlayerState
    {
        Run,
        Jump,
        Death,
    }

    // set player state and trigger corresponding animation
    public void SetPlayerState(PlayerState newState)
    {
        playerState = newState;
        switch (playerState)
        {
            case PlayerState.Run:
                anim.SetTrigger("Run");
                break;
            case PlayerState.Jump:
                anim.SetTrigger("Jump");
                break;
            case PlayerState.Death:
                anim.SetTrigger("Death");
                break;
        }
    }

    // move input action
    public void OnMove(InputValue inputValue)
    {
        horizontalInput = inputValue.Get<Vector2>().x;
    }

    // alternative method for move input action to allow for different input types
    public void MoveInput(Vector2 value)
    {
        horizontalInput = value.x;
    }

    // jump input action
    public void OnJump(InputValue inputValue)
    {
        hasJumped = inputValue.isPressed;
    }

    // alternative method for jump input action to allow for different input types
    public void JumpInput(bool value)
    {
        hasJumped = value;
    }
}