using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, Controls2D.IUIActions
{
    Controls2D MyControls;
    GameManager GM;

    public GameObject PauseMenuUI;
    public GameObject PauseInitialItem;
    public DebugMenu DebugMenu;

    private void Update()
    {
        //Debug.Log(MyControls.UINavigation.Start);
        //if (MyControls.UINavigation.Start) { MenuOpen = !MenuOpen; }    
    }

    void Awake()
    {
        //When the object first wakes up it's going to try to find and set the focus to be the game object "Main menu" 
        GM = GetComponent<GameManager>();
        StartCoroutine(SetMainMenuFocus());
    }

    private void OnEnable()
    {
        //So when this object is initially enabled we enable get and enable the controls for the UI
        if (MyControls == null)
        {
            //MyControls = new Controls2D();
            MyControls = GlobalVar.GlobalControls;
            //The convention for making it so this is the recieving object for the controls is 
            //C# Input Action -> Followed By An Action Set -> Followed by What the callbacks target
            //So if you have a controller manager that has drop in you could have it assign it to a "controllable" character for a beat em up
            MyControls.UI.SetCallbacks(this);
        }
        MyControls.UI.Enable();
    }


    #region UnImplemented UI Actions
    public void OnPoint(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    
    #endregion


    public void OnSelect(InputAction.CallbackContext context)
    {
      
        var InputContext = context.phase;
        //Debug.Log(InputContext);
        if (InputContext == InputActionPhase.Started){ }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
        throw new System.NotImplementedException();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        var InputContext = context.phase;
        //Debug.Log(InputContext);
        ///We run it on Phase Started because that is called once per button press
        if (InputContext == InputActionPhase.Started)
        {
            ///Then we pass our game state through a switch statement
            switch (GM.GetGameState()) {
                case GameState.MAINMENU:
                    {
                        ///If the GameManager believes its in the main menu then it will double check that
                        GM.DoubleCheckGameState();
                        Debug.Log("Pressing start in the main menu isn't supported yet");
                    }
                    break;
                case GameState.GAMEPLAY:
                    {
                        //So we ask to toggle the pause menu then enable our menu
                        SetPauseState(true);
                        //So we ask to menuto set its object to null then reset it to the start
                        GetComponent<EventSystem>().SetSelectedGameObject(null);
                        GetComponent<EventSystem>().SetSelectedGameObject(PauseInitialItem);
                    }
                    break;
                case GameState.GAMEMENU:
                    {
                        GetComponent<EventSystem>().SetSelectedGameObject(null);
                        SetPauseState(false);
                    }
                    break;
                case GameState.CUTSCENE:
                    {

                    }
                    break;
                default:
                    {
                        Debug.Log("How what?");
                    }
                    break;
            }
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }


    public void OnToggleDebug(InputAction.CallbackContext context)
    {

        var InputContext = context.phase;
        //Debug.Log(InputContext);
        if (InputContext == InputActionPhase.Started) 
        {
            //Toggles the debug Menu from enabled to disabled and vice versa
            DebugMenu.gameObject.SetActive(!DebugMenu.gameObject.activeSelf);
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }

    public void OnSwitchDebug(InputAction.CallbackContext context)
    {

        var InputContext = context.phase;
        //Debug.Log(InputContext);
        int direction = (int)context.ReadValue<float>();
        if (InputContext == InputActionPhase.Started)
        {
            //Toggles the debug Menu from enabled to disabled and vice versa
            Debug.Log(direction);
            DebugMenu.SwitchMenu(direction);
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }

    ///When Calling this method the game via UI Buttons or controller Buttons
    public void SetPauseState(bool PauseState)
    {
        //So 
        GM.TogglePause(PauseState);
        PauseMenuUI.SetActive(PauseState);
    }

    ///This is used to move to the main menu 
    ///It also has to unpause the game
    public void ToMainMenu()
    {
        Debug.Log("Moving To Main Menu");
        SetPauseState(false);
        GM.LoadMainMenu();
        StartCoroutine(SetMainMenuFocus());
    }

    ///This is used to ask the game manager to quit out of the game
    ///The reason why it isn't done here is because this manager is purely for menu states
    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        GM.QuitGame();
    }


    IEnumerator SetMainMenuFocus()
    {
        yield return new WaitForSeconds(1);
        Canvas CanvasObject = null;
        foreach(Canvas Target in FindObjectsOfType<Canvas>())
        {
            if (Target.name == "MainMenu") { 
                CanvasObject = Target; 
                break; 
            }
        }
        if (CanvasObject != null)
        {
            GetComponent<EventSystem>().SetSelectedGameObject(null);
            GetComponent<EventSystem>().SetSelectedGameObject(CanvasObject.GetComponentInChildren<Button>().gameObject);
        }
    }


}
