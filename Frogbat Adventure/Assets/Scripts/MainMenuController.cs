using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    
    public void StartGame()
    {
        Debug.Log("What?!");
        GetComponent<GameManager>().LoadStage("1-1");
    }

    public void OpenOptions()
    {

    }

    public void ExitApp()
    {
        Debug.Log("EXIT GAME");
        GetComponent <GameManager>().QuitGame();
    }
}
