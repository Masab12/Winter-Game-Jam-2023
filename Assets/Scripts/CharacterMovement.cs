using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpForce = 400.0f;
    public bl_Joystick joystick;
    public Rigidbody rb;
    public bool isGrounded = true;
    public Animator animator;
    public static bool isMoving, isDead;
    public bool isTimeOver = false;
    public bool isHoldingToy = false;
    public Transform hand;
    public GameObject toy;
    public float fakeGravity = 150f;
    public float airGravityMultiplier = 5f; // The multiplier for fake gravity when in the air
    private bool isInAir = false; // Whether the character is currently in the air
    public GameObject RoomParent;
    public Events events;

    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
        rb.mass = 0.5f;
        animator = GetComponent<Animator>();
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (isInAir)
        {
            rb.AddForce(transform.up * fakeGravity * airGravityMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(-transform.up * fakeGravity * airGravityMultiplier, ForceMode.Acceleration);
        }
    }

    void Update()
    {

        // Check if the game is paused
        if (events.isPaused)
        {
            rb.velocity = Vector3.zero; // Disable movement
            joystick.gameObject.SetActive(false); // Disable joystick controls
            return; // Exit the function
        }
        float moveX = joystick.Vertical;
        float moveZ = joystick.Horizontal;

        Vector3 movement = new Vector3(0f, 0f, moveZ);
        if (movement.magnitude > 1f) movement = movement.normalized;

        Vector3 moveDirection = Vector3.zero;
        if (movement.magnitude > 0f)
        {
            transform.rotation = Quaternion.LookRotation(-movement, Vector3.up);
            moveDirection = movement;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        rb.velocity = moveDirection * (-moveSpeed);

        if (moveDirection.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
            float temp = Mathf.Abs(moveDirection.z);
            animator.SetFloat("walkingSpeed", temp);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


    }

    public void Jump()
    {
        animator.SetTrigger("isJumping");
        rb.AddForce(transform.up * 50, ForceMode.Acceleration);
        isGrounded = false;
        isInAir = true;
        Invoke(nameof(Delay), 0.5f);
    }
    void Delay()
    {
        isInAir = false;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "Toy")
        {
            isHoldingToy = true;
            animator.SetTrigger("pickupTrigger");
            toy = other.gameObject;
            toy.transform.parent = hand;
            toy.transform.localPosition = Vector3.zero;
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Room")
        {

            this.transform.parent = col.transform;
            Debug.Log("Room Change");

        }
        if (col.gameObject.tag == "Enemy")
        {
            isDead = true;
            animator.SetTrigger("Die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}