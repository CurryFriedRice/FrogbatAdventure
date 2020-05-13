using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleOld : MonoBehaviour
{

    // A position marking where to check for the walls
    /*
    [SerializeField] private LayerMask m_whatIsBouncy;
    [SerializeField] private Transform m_right;							
    [SerializeField] private Transform m_left;
    [SerializeField] private Transform m_top;
    [SerializeField] private Transform m_bottom;
    *
    public float k_edgeRadius = 0f;
    */
    public int AnimCycles = 3;
    public Animator anim;

    public Rigidbody2D myRb;
    public float velocity;

    bool hasCollided = false;

    private void Awake()
    {

    }

    private void FixedUpdate()
    {

        /*while some parameter is true, 
        if the trigger is set by the left or right transforms, 
        immediately move to the next anim and reposition the parent object
        */


        /*
        rb.AddForce(new Vector2(0f, BoingPower));
        BoingPower = BoingPower + (Physics2D.gravity.y); //Jump Force - gravity
        if (BoingPower < 0f)
            BoingPower = 0f;
        */
    }

    private void Decay()
    {
        RepositionParent();
        if (AnimCycles <= 0)
        {
            anim.SetTrigger("BubblePop");
            
        }
        else
        {
            AnimCycles--;
            anim.SetTrigger("Boing");
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            print("Flipping Object");
        //    anim.SetTrigger("Flip");
        }
        
    }
    */

    private void DestroyMe()
    {
        //Destroy(this.transform.parent.gameObject);
        Destroy(gameObject);
    }

    private void RepositionParent()
    {
        if (transform.parent != null)
        {
            transform.parent.position = transform.position;
            transform.position = new Vector2(0, 0);
        }
    }
    

    public void SetVelocity()
    {
        myRb.isKinematic = false;
        myRb.velocity = new Vector3(velocity, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("i've collided");
        if (hasCollided == false)
        {
            hasCollided = true;
            Destroy(gameObject);
        }
       // anim.SetTrigger("Boing");
    }
}
