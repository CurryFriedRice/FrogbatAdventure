using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class D_Settings :MonoBehaviour
{
    public float MenuSliderAccel = 1f;

    //Slider Speed...
    public TestSettings Test;
    public AudioData Audio;
    public GraphicsData Graphics;
    public GameplayAccessibility Gameplay;

    public KeyboardControls Keyboard;
    public GamepadControls Gamepad;

    private D_Settings settings;

    public D_Settings(D_Settings settings)
    {
        this.settings = settings;
    }
}


[System.Serializable]
public class TestSettings
{
    //
    public float Value1;
    public bool Value2;
    public ButtonType Value3;
}

[System.Serializable]
public class GraphicsData
{
    //Audio Variables
    public ScreenRes Res;
    //Screen.resolutions.Length-1
    public FullScreenMode FullScreen = FullScreenMode.FullScreenWindow;
    public int ColorFilter;
}

[System.Serializable]
public class ScreenRes
{
    public int width = 1280;
    public int height = 720;
    public int refresh = 60;
}

[System.Serializable]
public class AudioData
{
    //Audio Variables
    public float Master = 1f;
    public float Music = 1f;
    public float Effects = 1f;
    public float Voice = 1f;
}


[System.Serializable]
public class GameplayAccessibility
{
    public Language Lang = Language.English;

    public float TimeScale  = 1f;
    
    public bool HoldToCarry = false;      //By Default This is off
    public bool HoldToFloat = true;    //By Default This is on

    public bool Flying = false;         //By Default this is off
    public bool QuickCheckpoint = false;//This makes it so it checks your last grounded point and respawns you there if you die
}

[System.Serializable]
public class KeyboardControls
{

}

[System.Serializable]
public class GamepadControls
{

}