using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AirDraft
{
    None,Up,Down,Left,Right
}

public class WindPower
{
    static float windPower = 2f;

    public static float getPower()
    {
        return windPower;
    }
}