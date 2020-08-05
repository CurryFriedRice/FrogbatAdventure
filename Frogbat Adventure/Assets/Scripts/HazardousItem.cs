using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HazardousItem : MonoBehaviour
{
    public int DamageAmount;
    public LaunchType Launch = LaunchType.NONE;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("This hazard has hit : " + collision.tag);
        switch (collision.tag)
        {
            case "Player":
                DamagePlayer(collision.GetComponent<Stats>());
                break;
            default:
                Debug.Log("UH OH HOT DOG");
                break;
        }
    }

    void DamagePlayer(Stats target)
    {
        if(target == null)
        {
            Debug.Log("UHHH TARGET HAS NO STATS!");
        }else 
            target.GetHit(DamageAmount, Launch);
    }

}
