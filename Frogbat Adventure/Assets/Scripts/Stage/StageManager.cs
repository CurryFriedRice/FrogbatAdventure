using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    GameManager GM;

    B_StageData CurrentStageData;
    B_StageData CheckpointData;

    int CheckpointNumber = 0;

    int BossPhase = 0;

    StageObjects StageObj;

    List<CollectItem> AllCollectibles = new List<CollectItem>(); 
    public void Setup(GameManager _GM)
    {
        GM = _GM;
    }
    


    //When you use a button to select a stage it'll pass in the Stage Data
    public void LoadStage(D_StageData StageData)
    {
        //CurrentStageData = new B_StageData(StageData);
        GM.SetMostRecentStage(StageData);
        GM.SaveFile();
        CheckpointData = new B_StageData(StageData);
        CheckpointNumber = 0;
        BossPhase = 0;
        LoadCheckpoint();
    }

    //This one is called when you complete a stage
    public void LoadStage(int StageIndex)
    {   
        //This is throwing a D_StageData to the other LoadStage based off the "Exit" you took to leave the stage
        LoadStage(GM.GetSaveFile().MostRecentStage.StageWarps[StageIndex]);        
    }

    //When we're attempting to move through menus we should be doing this version of loading stages.
    public void LoadStage(string StageName)
    {
        //Debug.Log(StageName);
        SceneManager.LoadScene(StageName);
        GM.SetGameState(GameState.GAMEPLAY);
    }



    public void LoadCheckpoint()
    {
        //So this will prompt a Scene load... Then place the player at the checkpoint. 
        //RE Load Scene
        //Reset the current StageData to the checkpoint data
        //The posititon of the SPAWN point is different than the checkpoint 
        //Place the player
        //then for each of the collectibles Turn off the one that was already collected;
        SceneManager.LoadScene(CheckpointData.SceneName);
        CurrentStageData = new B_StageData(CheckpointData);
        GM.SetMenuTransition(true);
        GM.SetGameState(GameState.GAMEPLAY);
    }


    public void SetCheckpoint(int _checkpoint)
    {
        Debug.Log("Checkpoint was set");
        CheckpointNumber = _checkpoint;
        CheckpointData = new B_StageData(CurrentStageData);
    }


    public void SetStageObjects(StageObjects _StageObj)
    {
        StageObj = _StageObj;//new StageObjects();
        //UpdateCollectibles();
        StageObj.Checkpoints[CheckpointNumber].SpawnPlayer(GM.CharPrefab);
        GM.SetMenuTransition(false);
    }

    public void UpdateCollectibles()
    {
        if(StageObj != null)
            for (int i = 0; i < CurrentStageData.CollectedCollectible.Length; i++) 
            {
                StageObj.Collectibles[i].SetActive(!CurrentStageData.CollectedCollectible[i]);
            }
    }



    public void GetCollectible(int CollectibleNum) 
    {
        if (CollectibleNum < 0 || CollectibleNum > CurrentStageData.CollectedCollectible.Length) Debug.LogError("The Collectible is pointing to a ");
        else
        {
            CurrentStageData.CollectedCollectible[CollectibleNum] = true;
        }
    
    }

    public void UnlockStage(int StageIndex)
    {
        Debug.Log("Most Recent Stage : " + GM.GetSaveFile().MostRecentStage.StageWarps[StageIndex].SceneName);
        GM.GetSaveFile().MostRecentStage.StageWarps[StageIndex].IsUnlocked = true;
    }

    public void CompleteStage()
    {
        GM.GetSaveFile().MostRecentStage.IsComplete = true;

    }

    public void SetBossPhase(int PhaseNum)
    {
        BossPhase = PhaseNum;
    }
}
