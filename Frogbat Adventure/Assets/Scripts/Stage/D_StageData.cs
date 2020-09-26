using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu (fileName = "New Stage", menuName = "Stage")]
public class D_StageData : ScriptableObject
{
    //This is used for general stage data

    //Every Stage will have a way to check if it's complete
    public bool IsComplete = false;
    public bool IsUnlocked = false;
    
    public bool HasCollectable = false;
    public bool[] CollectedCollectible = new bool[0];


    //Only Able Get Next Stages
    //Doors should call which stage to get 
    //e.g. Doors have Interact Events and we target that stage data and "LoadStage" 
    //Next Stage Warps 
    public List<D_StageData> StageWarps;

    //This one will probably not be used....
    public List<D_StageData> SecretStages; 
    
    //This SHould also be used to get Scene Names?
    public string SceneName;
    public string DisplayName = "NOT NAMED";
    public D_StageData(B_StageData BinaryData)
    {

    }

    public void SetFields(D_StageData StageData)
    {
        IsComplete = StageData.IsComplete;
        IsUnlocked = StageData.IsUnlocked;
        HasCollectable = StageData.HasCollectable;
        CollectedCollectible = StageData.CollectedCollectible;

        SceneName = StageData.SceneName;

        StageWarps.Clear();
        foreach(D_StageData stages in StageData.StageWarps)
        {
            StageWarps.Add(stages);
        }

    }

    public void SetFields(B_StageData StageData)
    {
        IsComplete = StageData.IsComplete;
        IsUnlocked = StageData.IsUnlocked;
        HasCollectable = StageData.HasCollectable;
        CollectedCollectible = StageData.CollectedCollectible;
    }

    public string UnlockNextStage(int stageIndex)
    {
        string NextStageName = "";
        if (stageIndex >= 0 && stageIndex < StageWarps.Count)
        {
            StageWarps[stageIndex].IsUnlocked = true;
            NextStageName = StageWarps[stageIndex].SceneName;
        }
        else
        {
            Debug.LogError("HEY! LOADING STAGE OUT OF WARP INDEX!");
        }
        return NextStageName;
    }

    public void UnlockSecretStage()
    {

    }
}

//Binary Stage Data that can be stored

[System.Serializable]
public class B_StageData
{
    public bool IsComplete = false;
    public bool IsUnlocked = false;
    
    //Basic Stage Collectibles
    public bool HasCollectable = false;
    public bool[] CollectedCollectible = new bool[0];

    public string SceneName;
    public B_StageData(D_StageData data)
    {
        IsComplete = data.IsComplete;
        IsUnlocked = data.IsUnlocked;
        HasCollectable = data.HasCollectable;
        CollectedCollectible = data.CollectedCollectible;
        SceneName = data.SceneName;
    }

    public B_StageData(B_StageData data)
    {
        IsComplete = data.IsComplete;
        IsUnlocked = data.IsUnlocked;
        HasCollectable = data.HasCollectable;
        CollectedCollectible = data.CollectedCollectible;
        SceneName = data.SceneName;
    }

}