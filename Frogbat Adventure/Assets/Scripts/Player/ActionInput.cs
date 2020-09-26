using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionInput : MonoBehaviour, Controls2D.IActionInputsActions
{
    /// <summary>
    /// The Action Inputter is used to read the "action" inputs and respond accordingly
    /// </summary>
    /// 

    #region Variables
    ///This is used to know where the projectiles are shooting from, it changes its angle according to what the player is pressing
    public GameObject ProjectilePoint;
    
    ///This is used to access the animator and set animation triggers or bools.
    public P_AnimController animController;
    
    ///This is the script that actually MOVES the character around. 
    public CharacterController2D controller;


    public bool UseToggle;

    ///This is used To hold the base abilities
    Ability A1Base; //Bubble
    Ability A2Base; //Grapple hook
    Ability A3Base; //Attack... OR NOTHING!

    List<ToggleButton> Button = new List<ToggleButton>();

    ///This is used for Override Shots and if it's above 0 then they'll get multiple shots
    int A1Count = 0;
    int A2Count = 0;
    int A3Count = 0;

    ///Basic abilities of that unit, these become null out once they're set.
    ///They're used for "override" abilities
    public Ability A1;
    public Ability A2;
    public Ability A3;

    ///A Delay that stops the player from RAPIDLY acting
    bool ActionReady = true;
    
    ///This is access to the GLOBAL controls
    Controls2D MyControls;
    #endregion

    void FixedUpdate()
    {
        ///This is used to ensure that the ability will always be hard reset at some point
        ///Right now everything has a cooldown of 1 second and will hard reset after 1.5 seconds
        if (!ActionReady) StartCoroutine(StartActionCD(1.5f));
    }

    ///When the client is enabled we set the controls.
    private void OnEnable()
    {
        if (MyControls == null)
        {
            //MyControls = new Controls2D();
            MyControls = GlobalVar.GlobalControls;
            //This is the C# Input Action -> Followed By An Action Set -> Followed by What the callbacks target
            MyControls.ActionInputs.SetCallbacks(this);
        }
        MyControls.ActionInputs.Enable();
    }

    ///When we destroy this object we also have to unset the callbacks so we aren't shooting calls to a null object
    void OnDestroy()
    {
        if (MyControls == null)
        {
            //MyControls = new Controls2D();
            MyControls = GlobalVar.GlobalControls;
            //This is the C# Input Action -> Followed By An Action Set -> Followed by What the callbacks target
            MyControls.ActionInputs.SetCallbacks(null);
        }
        MyControls.ActionInputs.Disable();
    }

    ///We use Awake because it's called before Start
    private void Awake()
    {
        SetAbility(ref A1Base, A1, 0);
        SetAbility(ref A2Base, A2, 0);
        SetAbility(ref A3Base, A3, 0);
    }

    #region Action Inputs
    public void OnAction1(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
        var InputContext = context.phase;

        //Debug.Log(InputContext);
        if (ActionReady == false) { }
        else if (Button.Count != 0 && InputContext == InputActionPhase.Started)
        {
            foreach(ToggleButton btn in Button) 
            {
                Debug.Log(btn.name);
                btn.Activate();
            } 
        }
        else if (InputContext == InputActionPhase.Started)
        {
            FireAbility(ref A1Base, ref A1, ref A1Count);
            StartCooldown();
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }


    }

    public void OnAction2(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();

        var InputContext = context.phase;
        //Debug.Log(InputContext);
        if (ActionReady == false)
        {

        }
        else if (InputContext == InputActionPhase.Started)
        {
            FireAbility(ref A2Base, ref A2, ref A2Count);
            StartCooldown();
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }

    public void OnAction3(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();

        var InputContext = context.phase;
        //Debug.Log(InputValue);
        if (ActionReady == false) { }
        else if (InputContext == InputActionPhase.Started)
        {
            FireAbility(ref A3Base, ref A3, ref A3Count);
            StartCooldown();
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    
}

    public void OnLBumper(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
        var InputContext = context.phase;

        Debug.Log(InputContext);
        if (ActionReady == false) { }
        else if (InputContext == InputActionPhase.Started) { }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }

    }

    public void OnLTrigger(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
        var InputContext = context.phase;

        if (ActionReady == false) { }
        else if (InputContext == InputActionPhase.Started) { }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }

    public void OnRBumper(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
        var InputContext = context.phase;

        if (InputContext == InputActionPhase.Started) { }
        else if (InputContext == InputActionPhase.Performed)
        {
            ProjectilePoint.transform.localEulerAngles = new Vector3(0, 0, 45);
        }
        else if (InputContext == InputActionPhase.Canceled)
        {
            ProjectilePoint.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void OnRTrigger(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
        var InputContext = context.phase;

        if (ActionReady == false) { }
        else if (InputContext == InputActionPhase.Started) { }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }
    #endregion


    /// <summary>
    /// Start Cooldown is the method called after every action, it helps delay the actions you can take
    /// Alternatively this can be converted into a "ReadyAction(bool isReady)" and use the animator to set whether or not the action is ready.
    /// </summary>
    void StartCooldown()
    {
        StopAllCoroutines();
        StartCoroutine(StartActionCD(1));
    }

    /// <summary>
    /// Currently this is just an aciton
    /// </summary>
    /// <returns>New WaitForSeconds(X)</returns>
    IEnumerator StartActionCD(float WaitTime)
    {
        ActionReady = false;
        //Debug.Log("Action Cooling Down");
        yield return new WaitForSeconds(WaitTime);
        StopAllCoroutines();
        ActionReady = true;
        //Debug.Log("Action Ready");
    }

    /// <summary>
    /// Shoot the ability that you're asking for, so for Action1 you would pass in A1Base, A1, A1Count
    /// </summary>
    /// <param name="BaseAbility"></param>
    /// <param name="NewAbility"></param>
    /// <param name="NewAbilityCount"></param>
    void FireAbility(ref Ability BaseAbility, ref Ability NewAbility, ref int NewAbilityCount)
    {
     
        if (NewAbilityCount > 0 && NewAbility != null)
        {
            NewAbility.Activate();
            NewAbilityCount--;
        }
        else if(BaseAbility != null)
        {
            BaseAbility.Activate();
        }
        else
        {
            Debug.Log("This does not exist");
        }
    }

    /// <summary>
    /// This sets the ability simiar to how you fire the ability; as such you need to pass in the base, new and shotcount
    /// </summary>
    /// <param name="BaseAbility"></param>
    /// <param name="NewAbility"></param>
    /// <param name="ShotCount"></param>
    void SetAbility(ref Ability BaseAbility, Ability NewAbility, int ShotCount)
    {
        if (BaseAbility == null)
        {
            BaseAbility = NewAbility;
            NewAbility = null;
        } else 
        { 
            
        }
    }


    /// <summary>
    /// So this sets a NEW ability, in a slot with the ability with the amount of shots it has.
    /// </summary>
    /// <param name="Slot"></param>
    /// <param name="NewAbility"></param>
    /// <param name="ShotCount"></param>
    public void SetTempAbility(int Slot, Ability NewAbility, int ShotCount) 
    {
        switch (Slot) 
        {
            case 0:
                SetAbility(ref A1, NewAbility, ShotCount);
                break;
            case 1:
                SetAbility(ref A2, NewAbility, ShotCount);
                break;
            case 2:
                SetAbility(ref A3, NewAbility, ShotCount);
                break;
            default:
                Debug.LogWarning("Hey you're attempting to set it to a slot that doesn't exist");
                break;


        }
    }

    public void OverrideBaseShot(int Slot, Ability NewAbility, int ShotCount)
    {
        switch (Slot)
        {
            case 0:
                SetAbility(ref A1Base, NewAbility, 0);
                break;
            case 1:
                SetAbility(ref A2Base, NewAbility, 0);
                break;
            case 2:
                SetAbility(ref A3Base, NewAbility, 0);
                break;
            default:
                Debug.LogWarning("Hey you're attempting to set it to a slot that doesn't exist");
                break;


        }
    }

    public void SetToggleTarget(ToggleButton target)
    {
        if(!Button.Contains(target))
        {
            //Debug.Log("Hey I'm adding:" + target.name);
            Button.Add(target);
        }
        else if (Button.Contains(target))
        {
            //Debug.Log("Hey I'm gonna remove:" + target.name);
            Button.Clear();
        }
 
    }
   
}
