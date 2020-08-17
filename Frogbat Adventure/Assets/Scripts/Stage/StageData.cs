using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu (fileName = "New Stage", menuName = "Stage")]
public class StageData : ScriptableObject
{
    //This is used for general stage data
    
    //Every Stage will have a way to check if it's complete
    public bool isComplete = false;
    public bool hasCollectable = false;

    //Only Able Get Next Stages
    //Doors should call which stage to get 
    //e.g. Doors have Interact Events and we target that stage data and "LoadStage" 
    public StageData[] NextStageWarps;

    //Only able to get MyStage... Even then you shouldn't be able to use it
    public Scene MyStage;

    //Starts Loading "MyStage" The Game Manage should Handle Transitions
    public void LoadStage()
    {
        SceneManager.LoadScene(MyStage.name);
    }

    
}
