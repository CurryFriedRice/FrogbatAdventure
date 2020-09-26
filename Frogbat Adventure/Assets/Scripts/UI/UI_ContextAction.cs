using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_ContextAction : MonoBehaviour
{
    protected MenuManager MenuMan;

    //This is used for the MAIN MENU context actions
    //It calls back to the manager to do the actual action
    //In this way we are able to make Context actions for every menu or Re-use the menu
    //

    protected virtual void Awake()
    {
        if (MenuMan == null) MenuMan = FindObjectOfType<MenuManager>();
    }
    protected virtual void OnEnable()
    {
        MenuMan.SetNewContext(this);
        Debug.Log("ENABLED CONTEXT" + name);
    }

    protected virtual void OnDisable()
    {
        MenuMan.GetBaseContext();
        Debug.Log("DISABLED CONTEXT " + name);
    }

    protected virtual void OnDestroy()
    {
        MenuMan.GetBaseContext();
        Debug.Log("CONTEXT HAS BEEN DESTROYED " + name);
    }
    public virtual void OnPoint()
    {
        
    }

    public virtual void OnClick()
    {
   
    }

    public virtual void OnMiddleClick()
    {
        
    }

    public virtual void OnRightClick()
    {
       
    }

    public virtual void OnScrollWheel()
    {
     
    }

    public virtual void OnNavigate()
    {
        MenuMan.ResetSliderAccel();
    }

    public virtual void OnSubmit()
    {
       //This should be handled by buttons for what is selected
    }

    public virtual void OnCancel()
    {
        MenuMan.ToggleMenu(null, false);
    }

    public virtual void OnTrackedDevicePosition()
    {
        
    }

    public virtual void OnTrackedDeviceOrientation()
    {
     
    }

    public virtual void OnMenu()
    {
        MenuMan.TogglePauseMenu();
    }

    public virtual void OnSelect()
    {
        
    }

    public void OnToggleDebug()
    {
        MenuMan.ToggleDebug();
    }

    public void OnSwitchDebug()
    {
        MenuMan.SwitchDebug(1);
    }

    public void OnSwitchDebug(int direction)
    {
        MenuMan.SwitchDebug(direction);
    }


}
