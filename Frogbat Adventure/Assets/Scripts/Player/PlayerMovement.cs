using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(P_AnimController))]
public class PlayerMovement : MonoBehaviour, Controls2D.IBaseMovementActions
{

    /// <summary>
    /// The PlayerMovement script is used to command the controller to move the object around.
    /// It also tells the animation controller what triggers to be setting
    /// </summary>
    public CharacterController2D controller;
    public P_AnimController animController;

    float horizontalMovement;

    bool jump = false;
    bool crouch = false;

    public float RunSpeed = 40;

    //This is the C# class generated through Input Actions
    Controls2D MyControls;


    private void OnEnable()
    {
        if(MyControls == null)
        {
            //MyControls = new Controls2D();
            MyControls = GlobalVar.GlobalControls;
            //This is the C# Input Action -> Followed By An Action Set -> Followed by What the callbacks target
            MyControls.BaseMovement.SetCallbacks(this);
        }
        MyControls.BaseMovement.Enable();
       
    }

    private void OnDestroy()
    {
        if (MyControls == null)
        {
            //MyControls = new Controls2D();
            MyControls = GlobalVar.GlobalControls;
            //This is the C# Input Action -> Followed By An Action Set -> Followed by What the callbacks target
            MyControls.BaseMovement.SetCallbacks(null);
        }
        MyControls.BaseMovement.Disable();
    }

    //This is calculated every frame to calculate the movement of the character.
    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
    }



    //Okay so for EACH action we have a public Callback that the player Input Dyncamically calls to do actions
    
    //We set the horizontal movement of our 
    public void OnMovement(InputAction.CallbackContext context) {

        Vector2 InputContext = context.ReadValue<Vector2>();
        horizontalMovement = InputContext.x * RunSpeed;
       
        if (horizontalMovement != 0)
        {
            animController.UpdateBools(P_AnimTriggers.IsMoving, true);
        }
        else
        {
            animController.UpdateBools(P_AnimTriggers.IsMoving, false);
        }
        
    }

    //The active jump Button and whether or not it is held down
    public void OnJump(InputAction.CallbackContext context) {

        var InputContext = context.phase;
        //Debug.Log("JUMP"+InputValue);

        if(InputContext == InputActionPhase.Started) {}
        else if(InputContext == InputActionPhase.Performed)
        {
            //Debug.Log("I am Jumping");
            jump = true;
            animController.UpdateBools(P_AnimTriggers.IsJumping, jump);
        }
        else if (InputContext == InputActionPhase.Canceled)
        {
            //Debug.Log("I let Go of jump");
            jump = false;
            animController.UpdateBools(P_AnimTriggers.IsJumping, jump);
        }

    }

    public void OnDrop_Through(InputAction.CallbackContext context)
    {
        
        var InputContext = context.phase;
        //Debug.Log("OnDrop_Through " + InputContext);
        
        if (InputContext == InputActionPhase.Started) 
        {
            controller.DropThroughPlatform();
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) 
        {
            controller.DropThroughPlatform();
        }
    }

}

