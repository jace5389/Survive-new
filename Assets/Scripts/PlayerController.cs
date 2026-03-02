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
    public TextMeshProUGUI powerupText;
    public TextMeshProUGUI timerText;
    public GameObject shieldVisual;
    public Animator anim;
    public GameManager gameManager;
    public PlayerState playerState;
    internal static object instance;
   
    // reference to animator and game manager
    public void Awake()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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
            hasJumped = false;
            SetPlayerState(PlayerState.Jump);
        }

        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // collision for ground and obstacles
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            SetPlayerState(PlayerState.Run);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (hasShield)
            {
                Destroy(collision.gameObject);
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
            shieldVisual.SetActive(true);

        shieldTimer = shieldDuration;

        Debug.Log("Shield ON");

        while (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;

            if (timerText != null)
                timerText.text = "Shield: " + Mathf.CeilToInt(shieldTimer) + "s";

            yield return null;
        }

        // Turn shield off
        hasShield = false;

        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        if (timerText != null)
            timerText.text = "";

        Debug.Log("Shield OFF");
    }

    public void ActivatePowerup()
    {
        if (powerupCoroutine != null)
        {
            StopCoroutine(powerupCoroutine);
        }
        powerupCoroutine = StartCoroutine(PowerupTimer());
    }

    IEnumerator PowerupTimer()
    {
        float powerupTimer = powerupDuration;
        Debug.Log("Powerup ON");
        while (powerupTimer > 0)
        {
            powerupTimer -= Time.deltaTime;
            powerupText.text = "Powerup: " + Mathf.CeilToInt(powerupTimer) + "s";
            yield return null;
        }
        hasPowerup = false;
        powerupText.text = "";
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

    public void MoveInput(Vector2 value)
    {
        horizontalInput = value.x;
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