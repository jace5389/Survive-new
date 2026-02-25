using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody playerRb;
    private Coroutine shieldCoroutine;
    public float jumpForce;
    public float gravityModifier;
    public float shieldDuration = 5f;
    public GameObject shieldVisual;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool hasShield = false;
    public int health = 3;
    float horizontalInput;
    bool hasJumped = false;
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
        shieldCoroutine = StartCoroutine(ShieldPowerUp());
    }

    // coroutine to handle shield powerup duration and visual effects
    IEnumerator ShieldPowerUp()
    {
        hasShield = true;
        shieldVisual.SetActive(true);
        yield return new WaitForSeconds(shieldDuration);
        hasShield = false;
        shieldVisual.SetActive(false);
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