using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpForce = 10.0f;
    public bl_Joystick joystick;
    public Rigidbody rb;
    private bool isGrounded = true;
    public Animator animator;
    public static bool isMoving;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
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
        if (isGrounded)
        {
            Debug.Log("JUMPPPP");
            rb.AddForce(Vector3.up * jumpForce * 12f, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}