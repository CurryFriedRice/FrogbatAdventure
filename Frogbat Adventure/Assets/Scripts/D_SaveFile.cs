using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D_SaveFile : MonoBehaviour
{

    public int FileNumber;
    public string FileName;
    public int Character; //Depending on the name your 

    public D_StageData MostRecentStage;

    public List<D_StageData> World1;
    public List<D_StageData> World2;
    public List<D_StageData> World3;
    public List<D_StageData> World4;
    public List<D_StageData> World5;
    //public PlayerStats stats;
    //public Checkpoint CP;



    //This is a special kind of collectible for the "dark" world
    public bool[] Secret = new bool[] { false, false, false, false, false, false };


    public void OverrideData(B_SaveFile file) 
    {
        if (file == null) 
        {
            Debug.Log("Save DOES NOT EXIST");


            return; 
        }
        FileNumber = file.FileNumber;
        FileName = file.Name;
        Character = file.Character;
        Debug.Log(file.MostRecentStage.SceneName);

        MostRecentStage.IsComplete = file.MostRecentStage.IsComplete;
        MostRecentStage.IsUnlocked = file.MostRecentStage.IsUnlocked;
        MostRecentStage.SceneName = file.MostRecentStage.SceneName;
        MostRecentStage.CollectedCollectible = file.MostRecentStage.CollectedCollectible;

        LoadWorldStats(file.World1, World1);
        LoadWorldStats(file.World2, World2);
        LoadWorldStats(file.World3, World3);
        LoadWorldStats(file.World4, World4);
        LoadWorldStats(file.World5, World5);

    }
    
    public void OverrideData(D_SaveFile file)
    {
        FileNumber = file.FileNumber;
        FileName = file.FileName;
        Character = file.Character;
    }

    public void LoadWorldStats(List<B_StageData> BasicData, List<D_StageData> DeployedData)
    {
        List<D_StageData> DisposableList = new List<D_StageData>(DeployedData);
        foreach (B_StageData binary in BasicData)
        {
            foreach (D_StageData dataObj in DisposableList)
            {
                if (dataObj.SceneName.Equals(binary.SceneName))
                {
                    Debug.Log(dataObj.SceneName + " | " + binary.SceneName);
                    dataObj.SetFields(binary);
                    DisposableList.Remove(dataObj);
                    break;
                }
            }
        }
    }


    public void Scrub()
    {
        //Clean all worlds...
        CleanWorld(World1);
        CleanWorld(World2);
        CleanWorld(World3);
        CleanWorld(World4);
        CleanWorld(World5);

        //MostRecentStage = World1[0];
        World1[0].IsUnlocked = true;
        MostRecentStage.SceneName = World1[0].SceneName;
        MostRecentStage.StageWarps = World1[0].StageWarps;
        MostRecentStage.SecretStages = World1[0].SecretStages;
        Debug.Log(MostRecentStage.SceneName);
        FileName = "";
        FileNumber = 0;
    }

    void CleanWorld(List<D_StageData> World)
    {
        foreach(D_StageData stage in World)
        {
            stage.IsComplete = false;
            stage.IsUnlocked = false;
            bool[] Collection = stage.CollectedCollectible;
            for(int i = 0; i< Collection.Length; i++)
            {
                Collection[i] = false;
            }
        }
    }
    
}


//Binary Save File...
[System.Serializable]
public class B_SaveFile
{
    public int FileNumber;
    public string Name;
    public int Character; //Depending on the name your 



    public B_StageData MostRecentStage;

    public List<B_StageData> World1 = new List<B_StageData>();
    public List<B_StageData> World2 = new List<B_StageData>();
    public List<B_StageData> World3 = new List<B_StageData>();
    public List<B_StageData> World4 = new List<B_StageData>();
    public List<B_StageData> World5 = new List<B_StageData>();

    //This is a special kind of collectible for the "dark" world
    public bool[] Secret = new bool[] { false, false, false, false, false, false };


    public B_SaveFile(D_SaveFile file)
    {


        FileNumber = file.FileNumber;
        Name = file.FileName;
        Character = file.Character;

        MostRecentStage = new B_StageData(file.MostRecentStage);

        SaveWorldStats(file.World1, World1);
        SaveWorldStats(file.World2, World2);
        SaveWorldStats(file.World3, World3);
        SaveWorldStats(file.World4, World4);
        SaveWorldStats(file.World5, World5);
    }
    
    public void SaveWorldStats(List<D_StageData> WorldData, List<B_StageData> SaveWorld)
    {
        foreach (D_StageData Data in WorldData)
        {
            B_StageData binary = new B_StageData(Data);
            SaveWorld.Add(binary);
        }
    }

    /*
    public void SaveWorldStats(List<D_StageData> DeployedData, List<B_StageData> BasicData)
    {
        List<D_StageData> DisposableList = DeployedData;
        foreach (B_StageData binary in BasicData)
        {
            foreach (D_StageData dataObj in DisposableList)
            {
                i++;
                if (dataObj.StageName.Equals(binary.StageName))
                {
                    Debug.Log(dataObj.StageName + " | " + binary.StageName);
                    dataObj.SetFields(binary);
                    DisposableList.Remove(dataObj);
                    break;
                }

            }
        }
    }
    */
}