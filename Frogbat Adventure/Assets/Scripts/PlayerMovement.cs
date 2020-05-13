using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator anim;
    public GameObject Bubble;

    float horizontalMovement;

    bool jump = false;
    bool crouch = false;
    bool isGliding = false;
    bool Action1Ready = true;

    public float RunSpeed = 40;
    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * RunSpeed;


        //Animator for the Movement commands
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        //Animator commands AND setting jump actions
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            anim.SetBool("IsJumping", false);
            jump = false;
            isGliding = false;
        }

        if (Input.GetButtonDown("Fire1") && Action1Ready)
        {
            anim.SetTrigger("Trigger1");
            StartCoroutine(StartAction1CD());
        }

        //Animator Command and Crouch actions
        if (Input.GetButtonDown("Crouch"))
        {
            anim.SetBool("IsCrouching", true);
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            anim.SetBool("IsCrouching", false);
            crouch = false;
        }
        CheckCrouching();
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
    }


    /*
    //Used as a debug for hitting stuff
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Mostly for debug checks
        print(other.name + "Has collided with me");
    }
    */



    //Animator Forced Calls
    public void SetGliding(bool set)
    {
        isGliding = set;
    }

    private void HitGround()
    {
        anim.SetBool("IsGrounded", true);
        anim.SetBool("IsFloating", false);
    }

    private void StopGrounded()
    {
        anim.SetBool("IsGrounded", false);
    }

    private void StartFloating()
    {
        anim.SetBool("IsFloating", false);
    }

    private void CheckCrouching()
    {
        if (controller.IsCrouching())
        {
            anim.SetBool("IsCrouching", true);
        }
        else
        {
            anim.SetBool("IsCrouching", false);
        }
    }

    private void Action1()
    {
        Bubble NewBub = Instantiate(Bubble).GetComponent<Bubble>();
        NewBub.CreateBubble(3 * transform.localScale.x, 3);
        //        NewBub.transform.localScale = transform.localScale;
        NewBub.transform.position = new Vector3(transform.position.x + (.5f * transform.localScale.x), transform.position.y + 0.5f, transform.position.z);
    }

    IEnumerator StartAction1CD()
    {
        Action1Ready = false;
        yield return new WaitForSeconds(1);
        Action1Ready = true;
    }

}

