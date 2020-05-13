using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bubble : MonoBehaviour
{
    public Rigidbody2D myRb;
    public Animator myAnim;
    AirDraft ExternalForce = AirDraft.None;
    GameObject ChildObject;
    //public float velocity;

    //bool hasCollided = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Is a debug command....
        //SetVelocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (ExternalForce)
        {
            case AirDraft.Up: //Upwards
                myRb.velocity = new Vector2(myRb.velocity.x, WindPower.getPower());
                break;
            case AirDraft.Right: //Right
                myRb.velocity = new Vector2(1, 0);
                break;
            case AirDraft.Down: //Down
                myRb.velocity = new Vector2(myRb.velocity.x, -1);
                break;
            case AirDraft.Left: //Left
                myRb.velocity = new Vector2(-1, 0);
                break;
            default:
                //print("There was no Tag");
                break;
        }
    }

    public void CreateBubble(float Velocity, float Duration)
    {
        //(Velocity);
        myRb.velocity = new Vector3(Velocity, 0, 0);
        StartCoroutine(LifeSpan(Duration));

    }

    IEnumerator LifeSpan(float Duration)
    {
        yield return new WaitForSeconds(Duration);
        myAnim.SetTrigger("DeathTrigger");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        
    }

    //As there become more things to hit 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("i've collided:" +collision.transform.name);
        //SImple switch to determine hit this do what
        switch (collision.transform.tag)
        {
            case "HardSurface":
                myAnim.SetTrigger("Trigger1");
                break;
            default:
                print("What is this...?" + collision.transform.name);
                break;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This isn't exactly Ideal
        switch (collision.transform.tag) {
            case "Effector1": //Upwards
                ExternalForce = AirDraft.Up;
                break;
            case "Effector2": //Right
                ExternalForce = AirDraft.Right;
                break;
            case "Effector3": //Down
                ExternalForce = AirDraft.Down;
                break;
            case "Effector4": //Left
                ExternalForce = AirDraft.Left;
                break;
            default:
                print("There was no Tag");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("huh");
        switch (collision.tag)
        {
            case "Effector1":
            case "Effector2":
            case "Effector3":
            case "Effector4":
                ExternalForce = AirDraft.None;
                break;
            default:
                break;
        }
    }



}
