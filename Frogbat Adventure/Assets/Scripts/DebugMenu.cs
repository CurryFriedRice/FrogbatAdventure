using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using Unity.Profiling;
using UnityEngine.Profiling;
using UnityEngine.UI;


public class DebugMenu : MonoBehaviour
{
    #region FrameRate Vars
        int frameCount = 0;
        float dt = 0.0f;
        float fps = 0.0f;
        float updateRate = 4.0f;
        NumberFormatInfo Digit = new NumberFormatInfo();
    #endregion

    DEBUG_MENUS CurrentMenu = DEBUG_MENUS.SYSTEM;
    bool Setup = false;
    public Image BackPanel;
    public Canvas DrawCanvas;
    public Vector2 ItemSizes;
    public TextMeshProUGUI TMProProxy;
    /*

    #region System Vars
    public TextMeshProUGUI FrameRate;
    public TextMeshProUGUI MemUsage;
    #endregion

    public GameObject StageMenu;
    #region Stage Vars
    public TextMeshProUGUI LevelName;
    public TextMeshProUGUI CheckNext;
    public TextMeshProUGUI CheckSecretNext;
    public TextMeshProUGUI CheckCollectible;
    #endregion

    public GameObject PlayerMenu;
    #region Player Vars
    public TextMeshProUGUI P_Health;
    public TextMeshProUGUI P_Shot;
    public TextMeshProUGUI P_Hook;
    public TextMeshProUGUI P_External;
    #endregion
    */

    // Start is called before the first frame update
    void Start()
    {
        Digit.NumberDecimalDigits = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentMenu)
        {

            case DEBUG_MENUS.SYSTEM:
                {
                    if (Setup == false) 
                    {
                        ResetMenu(ref BackPanel);
                        SetUpMenu(3, BackPanel, ItemSizes); 
                    }
                    TextMeshProUGUI[] DebugItems = GetComponentsInChildren<TextMeshProUGUI>();
                    SetData(ref DebugItems[0], "System Data : ", "(1/3)");
                    SetData(ref DebugItems[1], "FPS:", GetFrameRate());
                    SetData(ref DebugItems[2], "MEM:", GetMemoryUse());
                }
                break;

            case DEBUG_MENUS.STAGE:
                {
                    if (Setup == false)
                    {
                        ResetMenu(ref BackPanel);
                        SetUpMenu(5, BackPanel, ItemSizes);
                    }
                    TextMeshProUGUI[] DebugItems = GetComponentsInChildren<TextMeshProUGUI>();
                    SetData(ref DebugItems[0], "Stage Data : ", "(2/3)");
                    SetData(ref DebugItems[1], "Level: ", "N/A");
                    SetData(ref DebugItems[2], "Next Level: ", "N/A");
                    SetData(ref DebugItems[3], "Secret Level: ", "N/A");
                    SetData(ref DebugItems[4], "Collectible: ", "N/A");
                }
                break;

            case DEBUG_MENUS.PLAYER:
                {
                    if (Setup == false)
                    {
                        ResetMenu(ref BackPanel);
                        SetUpMenu(5, BackPanel, ItemSizes);
                    }
                    TextMeshProUGUI[] DebugItems = GetComponentsInChildren<TextMeshProUGUI>();
                    SetData(ref DebugItems[0], "Player Data : ", "(3/3)");
                    SetData(ref DebugItems[1], "Health: ", "N/A");
                    SetData(ref DebugItems[2], "Shot Type: ", "N/A");
                    SetData(ref DebugItems[3], "Hook Type: ", "N/A");
                    SetData(ref DebugItems[4], "External Force: ", "N/A");
                }
                break;

            default:
                break;
        }

    }
    
    
    void ResetMenu(ref Image Backpanel)
    {
        foreach(TextMeshProUGUI Child in Backpanel.GetComponentsInChildren<TextMeshProUGUI>())
        {
            Destroy(Child.gameObject);
        }
    }


    void SetUpMenu(int DebugCount, Image BackPanel, Vector2 PanelSize)
    {
        Setup = true;
        BackPanel.rectTransform.sizeDelta = new Vector2(PanelSize.x, PanelSize.y * (DebugCount));
        BackPanel.rectTransform.anchoredPosition = new Vector2(0, 0);

        TextMeshProUGUI NewText = Instantiate(TMProProxy, Vector3.zero, Quaternion.identity, BackPanel.rectTransform);
        NewText.rectTransform.sizeDelta = PanelSize;
        NewText.rectTransform.localPosition = new Vector3(PanelSize.x/2,-7.5f);
        NewText.gameObject.SetActive(true);

        int i = 1;
        while (i < DebugCount)
        {
            Debug.Log(DebugCount);
            i++;
            NewText = Instantiate(TMProProxy, Vector3.zero, Quaternion.identity, BackPanel.rectTransform);
            NewText.rectTransform.sizeDelta = PanelSize;
            NewText.rectTransform.localPosition = new Vector3(PanelSize.x / 2, -7.5f - (15*(i-1)));
            NewText.gameObject.SetActive(true);
        }


    }


    public void SwitchMenu(int Direction)
    {
        Setup = false;
        
        var length = System.Enum.GetNames(typeof(DEBUG_MENUS)).Length;
        
        // Depending on the value we want to increase or decrease
        // Then if we're decreasing we need check if we're below zero then to set our current value to 
        if (Direction > 0) CurrentMenu = (DEBUG_MENUS)(((int)CurrentMenu + 1) % length);
        else if (Direction < 0 && CurrentMenu > 0) CurrentMenu = (DEBUG_MENUS)(((int)CurrentMenu - 1));        
        else CurrentMenu = (DEBUG_MENUS)(((int)length- 1));
        
        Debug.Log("CurrentMenu: " + CurrentMenu);



    }

    #region System Info
    void SetData(ref TextMeshProUGUI display, string newString, float value)
    {

        display.text = newString + value;
    }

    void SetData(ref TextMeshProUGUI display, string newString, string value)
    {

        if (display != null)
        {
            display.name = newString;
            display.text = newString + value;
        }
    }


    string GetFrameRate()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1.0f / updateRate;
        }
        return fps.ToString("N", Digit) + "/" + Application.targetFrameRate;
    }

    string GetMemoryUse()
    {
        //Profiler.GetMonoHeapSize();
        return "N/A";
    }
    #endregion

    #region Stage Info
    void GetLevelName()
    {

    }

    void GetNextLevel()
    {

    }

    void GetSecretLevel()
    {

    }

    void GetCollectibles()
    {

    }
    #endregion

    #region Player Info
    void GetPlayerHealth() 
    { 
    
    }
    
    void GetPlayerShot() 
    { 
    
    }
    void GetPlayerHook() 
    {
    
    }
    
    void GetExternalVelocity() 
    { 
    
    }
    #endregion


}
