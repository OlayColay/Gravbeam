using System;
using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;    // The fastest the player can travel in the x axis.
    [SerializeField] private float m_JumpForce = 400f;  // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;  // A mask determining what is ground to the character
    [SerializeField] private float m_JumpTime = 1f;     // How long a player can move upwards in a jump

    PlayerControls controls;
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_IsJumping;           // If the player is holding the jump button down
    private float m_JumpTimeCounter;    // Remaining time left in jump
    

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Gravity.Move.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Gravity.Move.canceled += ctx => Move(0f);

        // controls.Gravity.Beam2.performed += ctx => beamDir2 = ctx.ReadValue<Vector2>();
        // controls.Gravity.Beam2.canceled += ctx => beamDir2 = Vector2.zero;

        controls.Gravity.Jump.performed += ctx => m_IsJumping = true;
        controls.Gravity.Jump.canceled += ctx => m_IsJumping = false;
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
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        m_Anim.SetBool("Ground", m_Grounded);

        // If the player should jump...
        if (m_IsJumping && m_Grounded && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.velocity += Vector2.up * m_JumpForce;
            m_JumpTimeCounter = m_JumpTime;
        }
        // If the player continues jumping...
        else if(m_IsJumping) 
        {
            if(m_JumpTimeCounter > 0)
            {
               m_Rigidbody2D.velocity += Vector2.up * m_JumpForce;
               m_JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                m_IsJumping = false;
            }
        }

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }


    public void Move(float move)
    {
        // Only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}