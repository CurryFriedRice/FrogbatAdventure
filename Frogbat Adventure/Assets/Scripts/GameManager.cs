using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameState MyGameState = GameState.MAINMENU;

    D_SaveFile SaveFileObj;
    D_Settings Settings;
    
    ///The Game Manager will handle things that pertain with Data

    //Things that pertain to opening and closing menus
    public MenuManager MenuMan;

    //Things that pertain to Loading and changing scenes
    public StageManager StageMan;

    public CharacterController2D CharPrefab;

    //The ScreenTransition
    Animator ScreenTransition;
        
    private void Awake()
    {
        ///THIS IS EXTREMELY IMPORTANT TO HAVE!
        ///What it does is tells the game to not remove itself from any scenes
        ///Though if it finds another game manager it is fully able to destroy that game manager.
        DontDestroyOnLoad(this.gameObject);
        if(FindObjectsOfType<GameManager>().Length != 1) { Destroy(this.gameObject); }

        ScreenTransition = GetComponentInChildren<Animator>();

        Settings = GetComponent<D_Settings>();


        //Set up the other Managers
        MenuMan = GetComponent<MenuManager>();
        if (MenuMan != null) MenuMan.Setup(this);
        else Debug.LogError("Menu Management is not present on GameManager");

        StageMan = GetComponent<StageManager>();
        if (StageMan != null) StageMan.Setup(this);
        else Debug.LogError("Stage Management is not present on GameManager");
        
        SaveFileObj = GetComponent<D_SaveFile>();
        //SaveFile = SaveSystem.LoadFile(SaveFile.FileNumber);

        Application.targetFrameRate = 60;
    }
    
    public void CreateNewFile(string _fileName, int _fileIndex)
    {
        SaveFileObj.Scrub();
        SaveFileObj.FileNumber = _fileIndex;
        SaveFileObj.FileName = _fileName;
        
        SaveSystem.SaveFile(SaveFileObj);
        StageMan.LoadStage(SaveFileObj.MostRecentStage.SceneName);
    }

    public D_Settings GetSettings()
    {
        return Settings;
    }
  
    public void ForcePause(bool isPaused)
    {
        //GlobalVar.PAUSED = !GlobalVar.PAUSED;
        GlobalVar.PAUSED = isPaused;
        FindObjectOfType<PlayerInput>().enabled = !GlobalVar.PAUSED;
        if (GlobalVar.PAUSED)
        {
            //So we set the timescale to 0 then Need to disable some controllers...
            //InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
            //FindObjectOfType<PlayerInput>().enabled = GlobalVar.PAUSED;
            
            GlobalVar.GlobalControls.BaseMovement.Disable();
            GlobalVar.GlobalControls.ActionInputs.Disable();
            SetGameState(GameState.GAMEMENU);
            Time.timeScale = 0f;
        }
        else
        {
            //InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
            
            GlobalVar.GlobalControls.BaseMovement.Enable();
            GlobalVar.GlobalControls.ActionInputs.Enable();
            SetGameState(GameState.GAMEPLAY);
            Time.timeScale = 1f;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(GlobalVar.MAINMENU_NAME);
        SetMenuTransition(true);
        StageMan.LoadStage(GlobalVar.MAINMENU_NAME);
        MyGameState = GameState.MAINMENU;
    }
    public void LoadStageSelect()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(GlobalVar.MAINMENU_NAME);
        SetMenuTransition(true);
        StageMan.LoadStage(GlobalVar.STAGESELECT_NAME);
        MyGameState = GameState.STAGESELECT;
    }


    //Portals will shout to load the next scene

    public GameState GetGameState()
    {
        return MyGameState;
    }

    public void SetGameState(GameState newState)
    {
        MyGameState = newState;
    }

    public void DoubleCheckGameState()
    {
        if(SceneManager.GetActiveScene().name == GlobalVar.MAINMENU_NAME)
        {
            Debug.Log("We're actually in the main menu!");
        }
        else
        {
            Debug.Log("Oh wow.... We're not in a main menu?\nSetting GameState to Gameplay");
            MyGameState = GameState.GAMEPLAY;
        }
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void SetFile(B_SaveFile file)
    {
        //If there is file data... Set it
        if (file != null)
        {
            SaveFileObj.OverrideData(file);
            Debug.Log("Most recent stage is... " + SaveFileObj.MostRecentStage.SceneName);
            StageMan.LoadStage(SaveFileObj.MostRecentStage);
            GetComponent<MenuManager>().ClearMenuStack();
        }
    }


    public D_SaveFile GetSaveFile()
    {
        return SaveFileObj;
    }

    public void SaveFile()
    {
        SaveSystem.SaveFile(SaveFileObj);
    }

    public void SetMostRecentStage(D_StageData LoadedStage)
    {
        D_StageData MostRecentStage = GetWorldData(LoadedStage.SceneName);

        Debug.Log("Kapoot!:" + MostRecentStage.SceneName);
        SaveFileObj.MostRecentStage.SetFields(MostRecentStage);
        Debug.Log("Kapoot!:" + MostRecentStage.SceneName);
    }

    D_StageData GetWorldData(string stageName)
    {
        foreach (D_StageData stage in SaveFileObj.World1)
        {
            //if (stage.SceneName == SaveFileObj.MostRecentStage.SceneName)
            if (stage.SceneName == stageName)
            {
                Debug.Log("I found the stage! " + stage.SceneName);
                return stage;
            }
        }
        foreach (D_StageData stage in SaveFileObj.World2)
        {
            //if (stage.SceneName == SaveFileObj.MostRecentStage.SceneName)
            if (stage.SceneName == stageName)
            {
                Debug.Log("I found the stage! " + stage.SceneName);
                return stage;
            }
        }
        foreach (D_StageData stage in SaveFileObj.World3)
        {
            //if (stage.SceneName == SaveFileObj.MostRecentStage.SceneName)
            if (stage.SceneName == stageName)
            {
                Debug.Log("I found the stage! " + stage.SceneName);
                return stage;
            }
        }
        foreach (D_StageData stage in SaveFileObj.World4)
        {
            //if (stage.SceneName == SaveFileObj.MostRecentStage.SceneName)
            if (stage.SceneName == stageName)
            {
                Debug.Log("I found the stage! " + stage.SceneName);
                return stage;
            }
        }
        foreach (D_StageData stage in SaveFileObj.World5)
        {
            //if (stage.SceneName == SaveFileObj.MostRecentStage.SceneName)
            if (stage.SceneName == stageName)
            {
                Debug.Log("I found the stage! " + stage.SceneName);
                return stage;
            }
        }

        Debug.Log("HEY WAIT! THIS ISN'T IN THE GAME MANAGER!");
        return null;
    }

    public void SetMenuTransition(bool FadeIn)
    {
        int TransitionNumber = Random.Range(0, 1)*3;
        if (FadeIn)
        {
            switch (TransitionNumber)
            {
                case 0:
                    ScreenTransition.SetTrigger(AnimTriggers.Action1.ToString());
                    break;
                case 1:
                    ScreenTransition.SetTrigger(AnimTriggers.Action2.ToString());
                    break;
                case 2:
                    ScreenTransition.SetTrigger(AnimTriggers.Action3.ToString());
                    break;
                default:
                    ScreenTransition.SetTrigger(AnimTriggers.Action1.ToString());
                    break;
            }
        }
        else
        {
            ScreenTransition.SetFloat(AnimTriggers.IdleLayer.ToString(), TransitionNumber);
            ScreenTransition.SetTrigger(AnimTriggers.ToIdle.ToString());
        }
    }



}
