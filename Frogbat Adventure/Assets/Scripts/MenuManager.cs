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
    EventSystem ES;
    GameManager GM;

    public GameObject PauseMenuUI;
    public GameObject PauseInitialItem;
    public DebugMenu DebugMenu;
    //public GameObject CanvasObj;
    UI_ContextAction BaseContextAction;

    Stack<GameObject> MenuStack = new Stack<GameObject>();
    GameObject CurrentMenu;

    void Update()
    {
        Debug.LogWarning(BaseContextAction.name) ;
    }

    public void Setup(GameManager _GM)
    {
        GM = _GM;
        ES = GetComponent<EventSystem>();
        StartCoroutine(SetMainMenuFocus());
        GetBaseContext();
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


    #region UI Actions from interface
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
        
        var InputContext = context.phase;
        //Debug.Log(context.performed);
        if (InputContext == InputActionPhase.Started){}
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }

    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        //This is handled by Buttons and the buttons will navigate deeper down
        //throw new System.NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();

        var InputContext = context.phase;
        //Debug.Log("Canecl: " + InputContext + "\nCanecl: " + context.performed);
        if (InputContext == InputActionPhase.Started) { }
        else if (InputContext == InputActionPhase.Performed)
        {
        BaseContextAction.OnCancel();
        }
        else if (InputContext == InputActionPhase.Canceled){ }
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }


    public void OnSelect(InputAction.CallbackContext context)
    {
        var InputContext = context.phase;
        //Debug.Log(InputContext);
        if (InputContext == InputActionPhase.Started){ }
        else if (InputContext == InputActionPhase.Performed) { BaseContextAction.OnSelect(); }
        else if (InputContext == InputActionPhase.Canceled) { }
        throw new System.NotImplementedException();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        var InputContext = context.phase;
        //Debug.Log(InputContext);
        ///We run it on Phase Started because that is called once per button press
        
        if (InputContext == InputActionPhase.Started){}
        else if (InputContext == InputActionPhase.Performed) { BaseContextAction.OnMenu(); }
        else if (InputContext == InputActionPhase.Canceled) { }
    }

    public void OnToggleDebug(InputAction.CallbackContext context)
    {

        var InputContext = context.phase;
        //Debug.Log(InputContext);
        if (InputContext == InputActionPhase.Started) 
        {
           BaseContextAction.OnToggleDebug();
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
            BaseContextAction.OnSwitchDebug(direction); 
        }
        else if (InputContext == InputActionPhase.Performed) { }
        else if (InputContext == InputActionPhase.Canceled) { }
    }
    #endregion


    public void SetNewContext(UI_ContextAction newContext)
    {
        //throw new System.NotImplementedException();
        BaseContextAction = newContext;
        Debug.Log(newContext.name);
    }

    public void GetBaseContext()
    {
        //throw new System.NotImplementedException();
        BaseContextAction = GetComponent<UI_ContextAction>();
        Debug.Log("Getting Base Context: " + BaseContextAction.name);
    }


    ///When Calling this method the game via UI Buttons or controller Buttons
    public void TogglePauseState()
    {
        GM.ForcePause(!GlobalVar.PAUSED);
        PauseMenuUI.SetActive(GlobalVar.PAUSED);
    }
    public void ForcePauseState(bool PauseState)
    {
        GM.ForcePause(PauseState);
        PauseMenuUI.SetActive(PauseState);
    }
    ///This is used to move to the main menu 
    ///It also has to unpause the game
    public void ToMainMenu()
    {
        Debug.Log("Moving To Main Menu");
        ForcePauseState(false);
        GM.SaveFile();
        ClearMenuStack();
        GM.LoadMenu();
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
            ES.SetSelectedGameObject(null);
            ES.SetSelectedGameObject(CanvasObject.GetComponentInChildren<Button>().gameObject);
        }
    }

    public void SetMenuFocus()
    {
        //Canvas CanvasObject = FindObjectOfType<Canvas>();
        Canvas CanvasObject = null;
        foreach (Canvas can in FindObjectsOfType<Canvas>())
        {
            if (can.GetComponent<Animator>() != null) { }
            else CanvasObject = can;
        }
        if (CanvasObject != null)
        {
            if (ES == null) ES = GetComponent<EventSystem>();
            ES.SetSelectedGameObject(null);
            ES.SetSelectedGameObject(CanvasObject.GetComponentInChildren<Button>().gameObject);
        }
    }


    public void ToggleMenu(GameObject Target, bool OpeningMenu)
    {
        if (GM.GetGameState() == GameState.MAINMENU || GM.GetGameState() == GameState.GAMEMENU)
        {
            if (OpeningMenu)
            {
                MenuStack.Push(CurrentMenu);
                CurrentMenu.SetActive(false);
                CurrentMenu = Target;
                CurrentMenu.SetActive(true);
                SetMenuFocus();
            }
            else if (MenuStack.Count != 0)
            {
                //When we close a menu what we want to do is take the item...
                CurrentMenu.SetActive(false);
                Debug.Log("The Peeked Value is..." + MenuStack);
                if (MenuStack.Peek() != null)
                {
                    CurrentMenu = MenuStack.Pop();
                    CurrentMenu.SetActive(true);
                }
                SetMenuFocus();
            }
            else
            {
                if (GM.GetGameState() == GameState.GAMEMENU)
                {
                    ForcePauseState(false);
                }
                Debug.Log("Menu Stack is empty....");
            }
        }
    }

    public void SetCurrent(GameObject newCurrent)
    {
        ClearMenuStack();
        CurrentMenu = newCurrent;
    }

    public void SetFocus(GameObject Target)
    {
        //GetComponent<EventSystem>().SetSelectedGameObject(null);
        ES.SetSelectedGameObject(null);
        ES.SetSelectedGameObject(Target);
    }

    public void SaveSettings()
    {
        Debug.Log("I Saved Settings");
        SaveSystem.SaveSettings(GM.GetSettings());
    }

    public void LoadSettings()
    {
        Debug.Log("I Loaded Settings");
        SaveSystem.LoadSettings(GM.GetSettings());
    }

    public void ResetSliderAccel()
    {
        GM.GetSettings().MenuSliderAccel = 1f;
    }

    public void ToggleDebug()
    {
        DebugMenu.gameObject.SetActive(!DebugMenu.gameObject.activeSelf);
    }

    public void SwitchDebug(int direction)
    {
        DebugMenu.SwitchMenu(direction);
    }

    public void TogglePauseMenu()
    {
        switch (GM.GetGameState())
        {
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
                    ForcePauseState(true);
                    //So we ask to menuto set its object to null then reset it to the start
                    //GetComponent<EventSystem>().SetSelectedGameObject(null);
                    //GetComponent<EventSystem>().SetSelectedGameObject(PauseInitialItem);
                    //ES.SetSelectedGameObject(null);
                    ES.SetSelectedGameObject(PauseInitialItem);
                }
                break;
            case GameState.GAMEMENU:
                {
                    //GetComponent<EventSystem>().SetSelectedGameObject(null);
                    ForcePauseState(false);
                    ES.SetSelectedGameObject(null);
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

    public void ClearMenuStack()
    {
        MenuStack.Clear();
    }

    public void SubmitFileName(string fileName, int _fileIndex)
    {
        GM.CreateNewFile(fileName, _fileIndex);
    }
}
