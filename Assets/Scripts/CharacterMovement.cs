using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpForce = 10.0f;
    public bl_Joystick joystick;
    public Rigidbody rigidbody;
    private bool isGrounded = false;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = joystick.Vertical;
        float moveZ = joystick.Horizontal;

        if (isGrounded && joystick.Horizontal > 0.5f)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        if (movement.magnitude > 1f) movement = movement.normalized; 

        Vector3 moveDirection = Vector3.zero;
        if (movement.magnitude > 0f)
        {
            
            transform.rotation = Quaternion.LookRotation(movement, Vector3.up);

            moveDirection = movement;
        }

        rigidbody.velocity = moveDirection * moveSpeed;

        if (moveDirection.magnitude > 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("walkingSpeed", moveDirection.z);
        }
        else
        {
            animator.SetBool("isWalking", false);
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