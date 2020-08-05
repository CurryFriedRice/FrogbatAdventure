using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameState MyGameState = GameState.MAINMENU;
    private void Awake()
    {
        ///THIS IS EXTREMELY IMPORTANT TO HAVE!
        ///What it does is tells the game to not remove itself from any scenes
        ///Though if it finds another game manager it is fully able to destroy that game manager.
        DontDestroyOnLoad(this.gameObject);
        if(FindObjectsOfType<GameManager>().Length != 1) { Destroy(this.gameObject); }
        Application.targetFrameRate = 60;
    }

    public void TogglePause(bool isPaused)
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

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GlobalVar.MAINMENU_NAME);
        MyGameState = GameState.MAINMENU;
      
    }

    //Portals will shout to load the next scene
    public void LoadStage(string StageName)
    {
        SceneManager.LoadScene(StageName);
        SetGameState(GameState.GAMEPLAY);
    }

    //used for Continue... WIll load up a file value to then toss into here.
    public void LoadLastPlayedStage()
    {

    }


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

}
