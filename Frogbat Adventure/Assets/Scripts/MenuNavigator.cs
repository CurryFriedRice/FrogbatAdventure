using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


//So this is a proxy class that calls out to the Menu Manager
public class MenuNavigator : MonoBehaviour
{
    GameManager GameMan;
    //MenuManager MenuMan;

    float PreviousValue = -1f;//This is so the slider knows what its previous value was
    float SlipValue = 0f;//This is used for normalizations of Sliders so moving is normalized from say 5 steps to 100

    float SliderVal = 0f;//This for the slider value 
    bool LoadedMenus = false;

    public GameObject InitialMenu;

    //public List<GameObject> MenusToLoad;

    void OnEnable()
    {
        if (GameMan == null) GameMan = FindObjectOfType<GameManager>();
        GameMan.MenuMan.SetCurrent(InitialMenu);
        //if (GameMan != null && MenuMan == null) MenuMan = GameMan.MenuManagement;
        //if (MenuMan != null) { MenuMan.SetCurrent(InitialMenu); }

        /*
        Screen.SetResolution(Settings.Graphics.Res.width, Settings.Graphics.Res.height, false);
        Screen.fullScreenMode = Settings.Graphics.FullScreen;
        */
    }


    public void StartGame()
    {
        //Debug.Log("What?!");
        if (GameMan == null) GameMan = FindObjectOfType<GameManager>();
        if (GameMan != null) GameMan.StageMan.LoadStage("1-1");
    }

    public void ExitApp()
    {
        Debug.Log("EXIT GAME");
        if (GameMan == null) GameMan = FindObjectOfType<GameManager>();
        if (GameMan != null) GameMan.QuitGame();
    }

    //So if we select a menu that needs more input we'll move to a preview page
    public void SetPreview()
    {
        
    }
    
    //This will be used by BUTTONS to move across Menus... mostly by shouting at the finding and shouting at the MenuManager...
    //Ensure that the button is run as such
    //Set the menu we are on, e.g. Open it
    //Then set the item we are to focus on. Usually the topmost item
    //IF We're running with a LB RB Menu Nav we'll forcefully call this?

    //OKAY So! Opening a Menu does not neccessarily mean we want navigate TO that menu
    //It's just SAYING to RENDER that menu
    public void OpenMenu(GameObject SetMenu)
    {
        //if(MenuMan == null) { MenuMan = FindObjectOfType<MenuManager>(); }
        if (GameMan!= null) { 
            //MenuMan.ToggleMenu(SetMenu, true);
            GameMan.MenuMan.ToggleMenu(SetMenu, true);
        }
    }
    
    //This closes tells the object to stop rendering
    public void CloseMenu(GameObject MenuToClose)
    {
        //if (MenuMan == null) { MenuMan = FindObjectOfType<MenuManager>(); }
        if (GameMan != null) {
            //MenuMan.ToggleMenu(MenuToClose, false); 
            GameMan.MenuMan.ToggleMenu(MenuToClose, false);
        }
    }

    //THIS is the important part, This is telling the Gmae to select the menu option
    public void SetFocus(GameObject FocusObj)
    {
        //if (MenuMan == null) { MenuMan = FindObjectOfType<MenuManager>(); }
        if (GameMan!= null) {
            //MenuMan.SetFocus(FocusObj); 
            GameMan.MenuMan.SetFocus(FocusObj);
        }
    }


    //So we want to set the slider
    public void SetSliderValue(Slider ValTarget)
    {   
        float AccelRate = 1f;
        float Normalized = ValTarget.normalizedValue;
        if (GameMan.GetSettings() != null)
        {
            D_Settings Settings = GameMan.GetSettings();
            switch (Settings.MenuSliderAccel)
            {
                case 1: //100 Steps
                    ValTarget.maxValue = 100 / 1;
                    //Apply the slip Value cause we let go and are normaling based off 100

                    //So if we're moving left
                    if (Mathf.Sign(PreviousValue - Normalized) < 0)
                    {
                        //And our previous direction was Left
                        if (Mathf.Sign(SlipValue) > 0) { SlipValue = -SlipValue; }//Do Nothing
                                                                                  //If our previous Direction was right
                        else { }
                    }
                    //So if we're moving right
                    else if (Mathf.Sign(PreviousValue - Normalized) > 0)
                    {
                        //And our previous direction was Left
                        if (Mathf.Sign(SlipValue) > 0) { }
                        //If our Direction was right... 
                        else { SlipValue = -SlipValue; }//Do nothing...
                    }
                    Normalized += SlipValue / 100;
                    SlipValue = 0;
                    break;
                case 5: //50 Steps -> Advancing by 2
                    ValTarget.maxValue = 100 / 2;
                    SlipValue = 1 * Mathf.Sign(PreviousValue - Normalized);
                    break;
                case 8: //25 Steps  -> Advancing by 5
                    ValTarget.maxValue = 100 / 4;
                    SlipValue = 4 * Mathf.Sign(PreviousValue - Normalized);
                    break;
                case 12://10 Steps -> Advancing by 10
                    ValTarget.maxValue = 100 / 10;
                    SlipValue = 9 * Mathf.Sign(PreviousValue - Normalized);
                    break;
                default:

                    break;
            }

            //-1 | -1 means Holding Left 1 | 1 means right or tapping 
            //Debug.Log(Mathf.Sign(PreviousValue - Normalized) + "|"+ SlipValue + "|" + Mathf.Sign(SlipValue));
            //SO if our current value is greater than the previous value.... Then we need to add...
            //If we're lower than the previous value then we need to add
            //Debug.Log(Normalized - PreviousValue);
            Settings.MenuSliderAccel += AccelRate;
            SliderVal = Normalized;
            ValTarget.normalizedValue = Normalized;

            //ValTarget.value += (1*Mathf.Sign(GlobalVar.MenuSliderAccel) + GlobalVar.MenuSliderAccel)/ValTarget.maxValue;
            //Debug.Log((1 * Mathf.Sign(GlobalVar.MenuSliderAccel) + GlobalVar.MenuSliderAccel) / ValTarget.maxValue);
            //Debug.Log(GlobalVar.MenuSliderAccel);
            PreviousValue = Normalized;
        }
        else Debug.LogWarning("THERE ARE NO SETTINGS ATTACHED TO THIS GAME MANAGER"); 
    }

    public void SetSpinnerValue() { }

    public void SetToggleValue() { }

    //This is used to help set Sliders
    public void SaveToVar(SettingsNames names, float val)
    {
        if (GameMan.GetSettings() == null) GameMan.MenuMan.LoadSettings();
        if (GameMan.GetSettings() != null)
        {
            D_Settings Settings = GameMan.GetSettings();
            switch (names)
            {
                case SettingsNames.AUD_MASTER:
                    Settings.Audio.Master = val;
                    break;
                case SettingsNames.AUD_MUSIC:
                    Settings.Audio.Music = val;
                    break;
                case SettingsNames.AUD_EFFECTS:
                    Settings.Audio.Effects = val;
                    break;
                case SettingsNames.AUD_VOICE:
                    Settings.Audio.Voice = val;
                    break;
                case SettingsNames.GP_TIMESCALE:
                    Settings.Gameplay.TimeScale = val;
                    break;
                default:
                    Debug.LogWarning(names.ToString() + " is not supported by floats");
                    break;
            }
        }
        else Debug.LogWarning("THERE ARE NO SETTINGS ATTACHED TO THIS GAME MANAGER");
    }

    //THIS IS USED TO HELP SET SPINNERS....
    public void SaveToVar(SettingsNames names, int val)
    {
        if (GameMan.GetSettings() == null) GameMan.MenuMan.LoadSettings();
        if (GameMan.GetSettings() != null)
        {
            D_Settings Settings = GameMan.GetSettings();
            switch (names)
            {
                case SettingsNames.GFX_FULLSCREEN:
                    Settings.Graphics.FullScreen = (FullScreenMode)val;
                    break;
                case SettingsNames.GFX_RES:
                    Resolution res = Screen.resolutions[val];
                    Settings.Graphics.Res.width = res.width;
                    Settings.Graphics.Res.height= res.height;
                    Settings.Graphics.Res.refresh = res.refreshRate;
                    break;
                default:
                    Debug.LogWarning(names.ToString() + " is not supported by floats");
                    break;
            }
        }
        else Debug.LogWarning("THERE ARE NO SETTINGS ATTACHED TO THIS GAME MANAGER");
    }

    public D_Settings GetSettings()
    {
        return GameMan.GetSettings();
    }
}
