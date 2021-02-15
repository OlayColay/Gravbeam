using System.Collections;
using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;      // The fastest the player can travel in the x axis.
    [SerializeField] private float jumpForce = 400f;    // Amount of force added when the player jumps.
    [SerializeField] private bool airControl = false;   // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask whatIsGround;    // A mask determining what is ground to the character
    [SerializeField] private float maxJumpTime = 1f;    // How long a player can move upwards in a jump
    [SerializeField] private float minJumpTime = 0.1f;  // The minimum time in a jump
    [SerializeField] private float wallSlideSpeed = 1f; // Speed a player slides down a wall
    [SerializeField] private float wallJumpMult = 0.7f; // The multiplier of jumpForce for a wall jump
    [SerializeField] private float wallScrambleMult;    // Multiplier of maxJumpTime for climbing up a wall

    PlayerControls controls;
    private float move = 0f;            // The value of horizontal movement (from -1 to 1)
    private Transform groundCheck;      // A position marking where to check if the player is grounded.
    const float groundedRadius = .2f;   // Radius of the overlap circle to determine if grounded
    private bool isGrounded;            // Whether or not the player is grounded.
    private Transform ceilingCheck;     // A position marking where to check for ceilings
    const float ceilingRadius = .01f;   // Radius of the overlap circle to determine if the player can stand up
    private Animator anim;              // Reference to the player's animator component.
    private Rigidbody2D rb;
    private bool facingRight = true;    // For determining which way the player is currently facing.
    private bool isJumping = false;     // If the player is holding the jump button down
    private float jumpTimeCounter;      // Remaining time left in jump
    private bool canJumpMore = false;   // If the player can continue jumping upwards
    private Transform wallCheck;        // Position where a player touching a wall is checked
    private bool isWalled = false;      // If the player is touching a wall
    private bool isSliding = false;     // If the player is sliding down a wall
    private bool isWallJumping = false; // If the player has jumped off a wall
    

    private void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        wallCheck = transform.Find("WallCheck");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Gravity.Move.performed += ctx => move = ctx.ReadValue<float>();
        controls.Gravity.Move.canceled += ctx => move = 0f;

        // controls.Gravity.Beam2.performed += ctx => beamDir2 = ctx.ReadValue<Vector2>();
        // controls.Gravity.Beam2.canceled += ctx => beamDir2 = Vector2.zero;

        controls.Gravity.Jump.started += ctx => Jump();
        controls.Gravity.Jump.canceled += ctx => isJumping = false;
    }

    private void OnEnable()
    {
        controls.Gravity.Enable();
    }
    private void OnDisable()
    {
        controls.Gravity.Disable();
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        isWalled = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
        anim.SetBool("Ground", isGrounded);

        Collider2D[] wallColliders = Physics2D.OverlapCircleAll(wallCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < wallColliders.Length; i++)
        {
            if (wallColliders[i].gameObject != gameObject)
                isWalled = true;
        }

        // If the player should be sliding down a wall...
        if (isWalled && !isGrounded && move != 0)
            isSliding = true;
        else
            isSliding = false;
        anim.SetBool("Walled", isSliding);

        Move(move);

        // If the player is sliding down a wall...
        if (isSliding)
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));

        // If the player continues jumping...
        if(canJumpMore && (isJumping || jumpTimeCounter < minJumpTime)) 
        {
            if(jumpTimeCounter < maxJumpTime * (isSliding ? wallScrambleMult : 1f))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * (isWallJumping ? wallJumpMult : 1));
                jumpTimeCounter += Time.deltaTime;
            }
            else 
                isJumping = isWallJumping = false;
        }
        else 
            canJumpMore = isJumping = isWallJumping = false;

        // Set the vertical animation
        anim.SetFloat("vSpeed", rb.velocity.y);

        if((facingRight && rb.velocity.x < -1) || (!facingRight && rb.velocity.x > 1))
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;
            // Rotate by 180 degrees
            transform.Rotate(new Vector3(0,180,0));
        }
    }

    public void Move(float move)
    {
        // Only control the player if grounded or airControl is turned on
        if (isGrounded || airControl || isSliding)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            if ((move > 0 && rb.velocity.x < maxSpeed) || (move < 0 && rb.velocity.x > -maxSpeed))
                rb.AddForce(new Vector2(move * maxSpeed * 10, rb.velocity.y));
        }
    }

    public void Jump()
    {
        // If the player should jump...
        if (isGrounded && anim.GetBool("Ground"))
        {
            JumpHelper();
            // Add a vertical force to the player.
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        // If the player is jumping from a wall...
        else if (isSliding && anim.GetBool("Walled"))
        {
            JumpHelper();
            isSliding = false;
            isWallJumping = true;
            anim.SetBool("Walled", false);
            rb.AddForce(new Vector2(maxSpeed * (facingRight ? -75 : 75), 0));
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce * wallJumpMult);
            if(airControl)
                StartCoroutine(delayAirControl());
        }
    }
    private void JumpHelper()
    {
        isJumping = canJumpMore = true;
        isGrounded = false;
        anim.SetBool("Ground", false);
        jumpTimeCounter = 0;
    }

    // Temporarily disable airControl so that a player can't infinitely climb a single wall
    private IEnumerator delayAirControl()
    {
        airControl = false;
        while(isWallJumping)
            yield return null;
        airControl = true;
    }
}