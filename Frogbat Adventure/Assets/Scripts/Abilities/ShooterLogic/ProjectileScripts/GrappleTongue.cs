using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GrappleTongue : MonoBehaviour
{
    //The Tongue Shoots out maybe 3 tiles diagonally at 45 degrees and 4 tiles forward.
    //Can only be used one time before landing.

    GameObject Creator;
    private void Awake()
    {
        if (Creator == null) Creator = GetComponent<BaseProjectile>().GetCreator();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I've collided with... " + collision.transform.name);

        switch (collision.transform.tag)
        {
            case "HardSurface":
            case "Platform":
                PullPlayer();
            break;
            case "Pullable":
            case "Snareable":
                //PullTarget();
            break;
            case "Eatable":
                //EatTarget();
            break;
            default:
                Debug.Log("Grapple Doesn't know!");
            break;
        }
    }



    void PullPlayer()
    {
        //Targets the player and then Applies a Pull Force 
        if (Creator == null) Creator = GetComponent<BaseProjectile>().GetCreator();
        if (Creator != null) Creator.GetComponent<Stats>().GetHit(0,LaunchType.GRAPPLE, GlobalVar.GrappleForce*3);
        DestroyThis();
    }

    //So this grapple tongue has is special in the sense that it needs to destroy the parent unit
    protected void DestroyThis()
    {
        if(transform.parent != null)Destroy(transform.parent.gameObject);
        Destroy(transform.gameObject);

    }
}
