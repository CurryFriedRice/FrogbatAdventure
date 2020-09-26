using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FileHolder : MonoBehaviour
{
    public int fileIndex;
    B_SaveFile basic;
    UI_FilePreviewer Previewer;
    
    
    private void Awake()
    {
        basic = SaveSystem.LoadFile(fileIndex);
        Previewer = GetComponentInParent<UI_FilePreviewer>();

    }


    //This is used when you CLICK on the button. Then It will LOCK IN save file and start the game
    public void SelectFile()
    {
   
         if (Previewer.GetFileContext() == FileSelectContext.Copy)
        {
            Debug.Log("COPY FILE " + Previewer.GetCopyIndex());
            if (Previewer.GetCopyIndex() == -1)
            {
                Debug.Log("COPY FILE Setting Index File");
                Previewer.SetCopyIndex(fileIndex);
            }else if (Previewer.GetCopyIndex() >= 0)
            {
                //Copy the file
                Debug.Log("COPY FILE Set");
                SaveSystem.CopyFile(Previewer.GetCopyIndex(), fileIndex);
                Previewer.SetCopyIndex(-1);

                //Then ask the previewer to re-load the file for previews. 
                basic = SaveSystem.LoadFile(fileIndex);
                Previewer.SetProgressFile(basic);
            }
        } 
        else if(Previewer.GetFileContext() == FileSelectContext.Delete)
        {
            SaveSystem.DeleteFile(fileIndex);

            basic = SaveSystem.LoadFile(fileIndex);
            Previewer.SetEmptyFile();
        }
        else if (basic == null)
        {
            //If Our file is non existant then we need to make the keyboard popup to enter a file name.
            Previewer.ToggleKeyboard(true, fileIndex);
        }
        else 
        {
            FindObjectOfType<GameManager>().SetFile(basic);
        }
    }



    //This is used to preview it in the UI
    public void PreviewSaveFile()
    {
        basic = SaveSystem.LoadFile(fileIndex);
        if (basic == null)
        {
            //So if the file does not exist when you select it Set the file to new GAme
            //So to show progress in a world it'll 
            Previewer.SetEmptyFile();
        }
        else
        {
            Previewer.SetProgressFile(basic);
        }
        //FIND ALL THE UI ELEMENTS THAT ARE NEEDED AND SET THE PREVIEW....
    }


}
