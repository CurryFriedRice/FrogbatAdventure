using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HelpText : MonoBehaviour
{

}

[System.Serializable]
public class AudioText
{
    public string Master = "How Loud the General Game should be";
    public string Music = "How Loud the Music should be";
    public string Effects = "How Loud the Effects should be";
}

[System.Serializable]
public class GraphicsText
{
    public string Resolution;
    public string FPS;
    public string ColorFilter = "Use a certain Schema";
}

[System.Serializable]
public class AccessibilityText
{
    public string Language = "What language the game should be";
    
    public string HoldToEat = "You need to HOLD the eat button to carry items";
    public string HoldToFloat = "You need to hold the button to slow your fall";
    
    public string Flying = "If this is on your float is now makes you fly";
    public string QuickCheckpoint = "Respawn where you were last on ground";

    
}