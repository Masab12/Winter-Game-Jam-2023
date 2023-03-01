using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform playerTransform; // reference to the player's transform
    public float attackDistance = 2.0f; // distance at which the monster will start attacking the player
    public float moveSpeed = 2.0f; // speed at which the monster moves towards the player
    public Animator animator; // reference to the animator component
    public float detectionDistance = 5.0f;
    private bool isAttacking = false; // flag to keep track of whether the monster is currently attacking
    private bool isMoving = false;
    private bool isDetecting = false;


    void Start()
    {
        // find the player's transform by tag
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= detectionDistance)
        {
            isDetecting = true;
        }

        // check if the player is within attack distance
        if (distanceToPlayer <= attackDistance)
        {
            // stop moving and start attacking
            isMoving = false;
            isAttacking = true;
        }
        else if(isDetecting)
        {
            // start moving towards the player
            isMoving = true;
            isAttacking = false;
        }

        
        

        // move towards the player
        if (isMoving)
        {
            transform.LookAt(playerTransform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        // play the attack animation if the monster is attacking
        if (isAttacking)
        {
            animator.SetTrigger("Attack");
        }
    }
}