using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

    [SerializeField] private Transform m_WallCheck_L;
    [SerializeField] private Transform m_WallCheck_R;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

    //Custom Parameter
    private float JumpForce = 0;
    public float LowGravity = 2f;
    public float HighGravity = 2.5f;
    public bool isFloating = false;
    private AirDraft DraftDirection = AirDraft.None;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
                JumpForce = m_JumpForce; //Used for 1.1 Jump

                if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

        Collider2D[] ceilColliders = Physics2D.OverlapCircleAll(m_CeilingCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                JumpForce = m_JumpForce; //Used for 1.1 Jump

                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }


    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
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
            } else
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


        // Move the character by finding the target velocity
        //Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        //transform.position = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


        //So the 
        Vector3 movementVector = Vector2.zero;
        
        Vector2 horizontalVector = (Vector2.right * move * 10f)*Time.deltaTime;
        Vector2 verticalVector = Vector2.zero;
        
        
        //Jump Code 1.1 - Removed physics to do a "force" based Jump

        //JumpForce = JumpForce + (Physics2D.gravity.y * Time.deltaTime); //Jump Force - gravity   
     /*
        if (JumpForce < Physics2D.gravity.y)
        {
            JumpForce = Physics2D.gravity.y;
            m_Grounded = false;
        }
    */

        //Jump Code 1.2 - Floatier Jump with harsher gravity at the end
        //If your velocity is negative you will fall faster
        if (jump)
        { 
            //This is set in the animator for simplicity's sake
            if (isFloating)
            {
                JumpForce = JumpForce + (Physics2D.gravity.y * (LowGravity - 1)*Time.deltaTime);
                if (JumpForce < (Physics2D.gravity.y / 2)) JumpForce /= 2;
            }
            else
            {
                JumpForce = JumpForce + (Physics2D.gravity.y * HighGravity - 1 ) * Time.deltaTime;
                if (JumpForce < (Physics2D.gravity.y)) JumpForce = Physics2D.gravity.y;
            }
            verticalVector = Vector2.up * JumpForce * Time.deltaTime;
        }//If your velocity is positive your velocity is reduced less than normal
        else if(!jump)
        {
            //verticalVector += (Vector2.up * Physics2D.gravity.y * (LowGravity - 1) * Time.deltaTime);
            if (JumpForce > 0) JumpForce = 0;
            JumpForce = JumpForce + (Physics2D.gravity.y * LowGravity - 1) * Time.deltaTime;
            //m_Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (LowGravity - 1) * Time.deltaTime;
        }

        if (!m_Grounded)
        {
            verticalVector = Vector2.up * JumpForce * Time.deltaTime;
        }

        movementVector = horizontalVector + verticalVector;
        transform.position = transform.position + movementVector;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //This isn't exactly Ideal
        print("I have entered");
        switch (collision.transform.tag)
        {
            case "Effector1": //Upwards
                DraftDirection = AirDraft.Up;
                break;
            case "Effector2": //Right
                DraftDirection = AirDraft.Right;
                break;
            case "Effector3": //Down
                DraftDirection = AirDraft.Down;
                break;
            case "Effector4": //Left
                DraftDirection = AirDraft.Left;
                break;
            default:
                print("There was no Tag");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Effector1":
            case "Effector2":
            case "Effector3":
            case "Effector4":
                DraftDirection = AirDraft.None;
                break;
            default:
                break;
        }
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
