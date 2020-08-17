using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToggleable
{
    void Toggle();
    void ToggleOn();
    void ToggleOff();

}

//Scripts that Use IToggleable
/* Toggleable
 * Cannon
 * RailRider
 */