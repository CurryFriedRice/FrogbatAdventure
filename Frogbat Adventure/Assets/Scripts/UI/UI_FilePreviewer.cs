using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_FilePreviewer : MonoBehaviour
{
    public GameObject Keyboard;
    public GameObject FileSelectButtons;
    public GameObject NewGameText;
    Button PreviousFileSelected;


    public int copyIndex;

    public Image CharacterSprite;

    public GameObject FilePreview;
    public GameObject NewFile;


    public TextMeshProUGUI FileName;
    public TextMeshProUGUI PlayTime;

    [Header("Worlds")]
    [Space]
    public Image[] WorldCompletionImage;
    public TextMeshProUGUI[] WorldCompletionText;
    [Header("Collectibles")]
    [Space]
    public Image[] CollectibleImages;
    public TextMeshProUGUI[] CollectibleText;


    [Header("SecretKeys")]
    [Space]
    public Image[] SecretKeysIcons;


    FileSelectContext FileSelect;
    private void OnEnable()
    {
        FileSelect = FileSelectContext.StartGame;
    }

    public void ToggleKeyboard(bool open, int FileIndex)
    {
        //So we're going to push down 
        if (open) 
        { 
            FindObjectOfType<GameManager>().MenuMan.ToggleMenu(Keyboard, true);
            Keyboard.GetComponent<UI_ContextKeyboard>().SetFileIndex(FileIndex);
        }
        else FindObjectOfType<GameManager>().MenuMan.ToggleMenu(null, false);

        //Keyboard.SetActive(open);
        //FileSelectButtons.SetActive(!open);
        //NewGameText.SetActive(!open);
    }

    public void SetEmptyFile()
    {
        //Debug.LogError("THERE IS NO FILE! BUILD THIS HANDLER!");
        FilePreview.SetActive(false);
        NewFile.SetActive(true);
    }

    public void SetProgressFile(B_SaveFile data)
    {
        //CharacterSprite.sprite = CharacterSprites[data.Character];

        FilePreview.SetActive(true);
        NewFile.SetActive(false);

        FileName.text = data.Name;


        SetWorldProgress(data.World1, WorldCompletionImage[0], WorldCompletionText[0], CollectibleImages[0], CollectibleText[0]);
        SetWorldProgress(data.World2, WorldCompletionImage[1], WorldCompletionText[1], CollectibleImages[1], CollectibleText[1]);
        SetWorldProgress(data.World3, WorldCompletionImage[2], WorldCompletionText[2], CollectibleImages[2], CollectibleText[2]);
        SetWorldProgress(data.World4, WorldCompletionImage[3], WorldCompletionText[3], CollectibleImages[3], CollectibleText[3]);
        SetWorldProgress(data.World5, WorldCompletionImage[4], WorldCompletionText[4], CollectibleImages[4], CollectibleText[4]);
        //SetWorldProgress(data.World6, WorldCompletionImage[5], WorldCompletionText[5], CollectibleImages[0], CollectibleText[0]));
        SetKeys(data.Secret);
    }

    void SetWorldProgress(List<B_StageData> data, Image image, TextMeshProUGUI StagesCompleteText, Image CollectibeImage,TextMeshProUGUI CollectiblesCollectedText)
    {

        //if(data[0] == null || !data[0].IsUnlocked)
        if (data == null || data.Count == 0)
        {
            image.enabled = false;
            StagesCompleteText.enabled = false;

            CollectibeImage.enabled = false;
            CollectiblesCollectedText.enabled = false;
        }
        else
        {
            //if (data[0].IsUnlocked)
            if (data == null)
            {
                image.enabled = true;
                StagesCompleteText.enabled = true;

                CollectibeImage.enabled = true;
                CollectiblesCollectedText.enabled = true;
            }
            int StagesComplete = 0, StagesTotal = 0, CollectiblesGotten = 0, CollectiblesTotal = 0;
            foreach(B_StageData stage in data) 
            {
                if (stage.IsComplete) StagesComplete++;
                StagesTotal ++;
                foreach(bool collected in stage.CollectedCollectible)
                {
                    if (collected) CollectiblesGotten++;
                    CollectiblesTotal++;
                }
            }
            StagesCompleteText.text = (StagesComplete + "/" + StagesTotal);
            CollectiblesCollectedText.text = (CollectiblesGotten + "/" + CollectiblesTotal);
        }
    }

    void SetKeys(bool[] Secrets)
    {
        int i = 0;
        foreach (bool collected in Secrets)
        {
            if (i > SecretKeysIcons.Length) 
            {
                Debug.LogWarning("There are more secret collectibles than there are Icons");
                return; 
            }
            SecretKeysIcons[i].enabled = collected;
            i++;
        }
    }

    public void SetFileContext(int Type)
    {
        if (FileSelect == (FileSelectContext)Type) FileSelect = FileSelectContext.StartGame;
        else FileSelect = (FileSelectContext)Type;
        Debug.Log(FileSelect.ToString());
        if (FileSelect == FileSelectContext.Copy) copyIndex = -1;
    }

    public FileSelectContext GetFileContext()
    {
        //Debug.Log("The File Context is:" + FileSelect);
        return FileSelect;
    }

    public int GetCopyIndex()
    {
        return copyIndex;
    }

    public void SetCopyIndex(int index)
    {
        copyIndex = index;
    }
}
