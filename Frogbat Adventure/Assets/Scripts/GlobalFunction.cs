using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class GlobalFunction
{
    public static SliderValues SliderStringToEnum(string val)
    {
        switch (val.ToUpper())
        {
            case "MASTER":
            case "A_MASTER":
            case "MAS":
                return SliderValues.A_Music;
            case "MUSIC":
            case "A_MUSIC":
            case "MUS":
                return SliderValues.A_Music;
            case "A_EFFECTS":
            case "EFF":
            case "SFX":
                return SliderValues.A_Effects;
            case "G_BRIGHTNESS":
            case "BRIGHTNESS":
            case "LIGHTING":
                return SliderValues.G_Brightness;
            default:
                return SliderValues.NONE;
        }

    }

    public static void SaveSettings()
    {
        
    }

    public static void LoadSettings()
    {

    }

}
