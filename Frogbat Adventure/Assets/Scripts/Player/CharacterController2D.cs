using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
    [SerializeField] private float BonusJumpForce = 15f;
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    private Vector3 ExternalVelocity = Vector2.zero;
    


    //Custom Parameter
    private float JumpForce = 0;
    public bool isFloating = false;
    
    private GameObject CurrentPlatform;
    public bool floatingEnabled = true;
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        //Debug.Log(m_WhatIsGround.value);
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius*Mathf.Abs(transform.localScale.x), m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (m_Rigidbody2D.velocity.y <= 0)
                {
                    JumpForce = m_JumpForce; //Used for 1.1 Jump
                    
                    if (floatingEnabled)
                    {
                        JumpForce += BonusJumpForce; //* transform.localScale.y;
                    }
                }
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
       
            }
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius * Mathf.Abs(transform.localScale.x), m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }
                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;
                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            ExternalVelocity = Vector2.Lerp(ExternalVelocity, Vector2.zero, 0.1f);
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f * Mathf.Abs(transform.localScale.x), m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity+ExternalVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            // Add m_Grounded if you want to lock float direction.
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

    


        Vector2 VerticalVector = Vector2.zero;

        //Jump Code 1.2 - Floatier Jump with harsher gravity at the end

        //If your velocity is negative you will fall faster
        //if (m_Rigidbody2D.velocity.y < 0)

        //float ScaledLowGrav = Physics2D.gravity.y * transform.localScale.y;
        //float ScaledHighGrav = Physics2D.gravity.y * transform.localScale.y;

        float ScaledGrav = Physics2D.gravity.y * transform.localScale.y;

        if (floatingEnabled)
        {
            if (jump && JumpForce > 0)
            {
                ToggleHeadCollider(true);
                JumpForce = JumpForce + (ScaledGrav * (GlobalVar.LowGravity - 1));
                VerticalVector = Vector2.up * JumpForce;
            }
            else if (jump && JumpForce < 0)
            {
                ToggleHeadCollider(true);
                if (m_Rigidbody2D.velocity.y < ScaledGrav / 4)
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, ScaledGrav / 4);
            }
            else if (JumpForce < 0 || !jump)
            {
                ToggleHeadCollider(false);
                if (JumpForce > 0) JumpForce = 0;
                else if (JumpForce < ScaledGrav) JumpForce = ScaledGrav;
                JumpForce = JumpForce + (ScaledGrav * (GlobalVar.HighGravity - 1));
                VerticalVector = Vector2.up * JumpForce; //* transform.localScale.y
            }
            m_Rigidbody2D.velocity += VerticalVector*Time.deltaTime;
        }
        else
        {
            if (jump && JumpForce > 0)
            {
                ToggleHeadCollider(true);
                JumpForce = JumpForce + (ScaledGrav * (GlobalVar.LowGravity - 1));
                VerticalVector = Vector2.up * JumpForce;

            }           
            else if (JumpForce < 0 || !jump)
            {
                ToggleHeadCollider(false);
                if (JumpForce > 0) JumpForce = 0;
                else if (JumpForce < ScaledGrav) JumpForce = ScaledGrav;
                JumpForce = JumpForce + (ScaledGrav * (GlobalVar.HighGravity - 1));
                VerticalVector = Vector2.up * JumpForce; //* transform.localScale.y

            }

            m_Rigidbody2D.velocity += VerticalVector * Time.deltaTime;
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

    private void SetFloating(bool Floating)
    {
        isFloating = Floating;
    }

    public bool IsCrouching()
    {
        return m_wasCrouching;
    }

    public bool Launch(LaunchType Type, Vector2 Direction)
    {
        //Debug.Log("I've been launched");
        //m_Rigidbody2D.AddRelativeForce(new Vector2(m_Rigidbody2D.velocity.x + 700 * transform.localScale.x, 0*m_Rigidbody2D.velocity.y + 500*transform.localScale.y));
        switch (Type) {
            case LaunchType.GRAPPLE:
                {
                    if (m_Grounded)
                        ExternalVelocity = new Vector2(15 * transform.localScale.x, 7f);
                    else
                        ExternalVelocity = new Vector2(15 * transform.localScale.x, 3.5f);
                    JumpForce = 0;
                }
                break;
            case LaunchType.DAMAGE:
                {
                    if (m_Grounded) ExternalVelocity = new Vector2(-7.5f * transform.localScale.x, 5f);
                    else ExternalVelocity = new Vector2(-7.5f * transform.localScale.x, 0f);
                    StartCoroutine(TempDisableControls());
                    JumpForce = 0;
                }
                break;
            case LaunchType.NONE:
                break;
            default:
                break;
        }

    return true;
    }

    void ToggleHeadCollider(bool b)
    {
        if (m_CrouchDisableCollider != null)
        {
            m_CrouchDisableCollider.enabled = b;
        }
    }

    
    public void DropThroughPlatform()
    {
        
        //Debug.Log(LayerMask.GetMask("Player"));
        JumpForce = 0;
        if (m_WhatIsGround == GlobalVar.PlayerGround)
        {
            ExternalVelocity = new Vector2(0, -1.5f);
            Physics2D.IgnoreLayerCollision(8, 9);
            m_WhatIsGround = GlobalVar.DropThroughPlatform;
            //ToggleHeadCollider(false);
        }
        else if(m_WhatIsGround == GlobalVar.DropThroughPlatform)
        {
            StopCoroutine(DelayDrop());
            StartCoroutine(DelayDrop());
            //ToggleHeadCollider(true);
        }
        //m_WhatIsGround = GlobalVar.DropThroughPlatform;
    }
    IEnumerator DelayDrop()
    {
        yield return new WaitForSeconds(.25f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        m_WhatIsGround = GlobalVar.PlayerGround;
    }

    public void SwapElement(Element type)
    {
        
    }

    IEnumerator TempDisableControls()
    {
        GlobalVar.GlobalControls.BaseMovement.Disable();
        yield return new WaitForSeconds(0.1f);
        GlobalVar.GlobalControls.BaseMovement.Enable();
    }

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bubble")
        {
            //m_Rigidbody2D.velocity = new Vector2(0f, 0f);
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, -collision.rigidbody.velocity.y);
        }    
    }
    */

}
