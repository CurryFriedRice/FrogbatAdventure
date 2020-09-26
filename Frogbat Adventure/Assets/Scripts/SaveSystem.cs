using UnityEngine;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveSettings (D_Settings settings)
    {
        D_Settings SavedSettings = settings;
        string path = Application.persistentDataPath + "/settings.json";
        Debug.Log(path);
        string Output = JsonUtility.ToJson(SavedSettings, true);
        System.IO.File.WriteAllText(path, Output);

        /*
        D_Settings SavedSettings = new D_Settings(settings);
        string path = Application.persistentDataPath + "/settings.json";
        JsonUtility.ToJson(SavedSettings,true);
        */
        //FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        //
    }

    public static void LoadSettings(D_Settings settings)
    {
        //string path = Application.persistentDataPath + "/settings.json";
        //FileStream stream = new FileStream(path, FileMode.Open);
        //stream.Close();
        string path = Application.persistentDataPath + "/settings.json";
        if (System.IO.File.Exists(path))
        {
            string input = System.IO.File.ReadAllText(path);
            //string path = 
            //string Input = JsonUtility.ToJson();
            JsonUtility.FromJsonOverwrite(input, settings);
        }
        else 
        { 
            Debug.Log("Settings Not Found: Making New Settings");
            SaveSettings(settings);
        }
    }

    public static void SaveFile(D_SaveFile FileData)
    {
        Debug.Log("Saving File!");
        BinaryFormatter formatter = new BinaryFormatter();
        int fileIndex = FileData.FileNumber;
        string path = Application.persistentDataPath + "/save" + fileIndex.ToString() + ".rice";

        FileStream stream = new FileStream(path, FileMode.Create);

        B_SaveFile data = new B_SaveFile(FileData);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    /*
    public static D_SaveFile LoadFile(int fileIndex)
    {
        string path = Application.persistentDataPath + "/save" + fileIndex+ ".rice";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            B_SaveFile BinarySave = formatter.Deserialize(stream) as B_SaveFile;
            stream.Close();

            D_SaveFile save = new D_SaveFile(BinarySave);
            return save;
        }
        else 
        {
            Debug.LogWarning("File does not exist");
            return null;
        }
    }
    */

    public static B_SaveFile LoadFile(int fileIndex)
    {
        Debug.Log("Loading File Data!");
        string path = Application.persistentDataPath + "/save" + fileIndex + ".rice";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            B_SaveFile BinarySave = formatter.Deserialize(stream) as B_SaveFile;
            stream.Close();

            //D_SaveFile save = new D_SaveFile(BinarySave);
            return BinarySave;
        }
        else
        {
            Debug.LogWarning("File does not exist");
            //We Return null So we know to "make a new game"
            return null;
        }
    }

    public static void DeleteFile(int index)
    {
        string path = Application.persistentDataPath + "/save" + index + ".rice";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void CopyFile(int BaseIndex, int ToIndex)
    {
        string OGPath = Application.persistentDataPath + "/save" + BaseIndex + ".rice";
        string CopyPath = Application.persistentDataPath + "/save" + ToIndex + ".rice";
        if (File.Exists(OGPath))
        {
            FileUtil.CopyFileOrDirectory(OGPath, CopyPath);
        }
        else
        {
            Debug.Log("Hey that file doesn't exist!");
            //Then play the Dwoot Sound;
        }
    }
}
