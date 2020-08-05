using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpitBubble : BaseProjectile
{
    Element MyElement = Element.NONE;

    protected override void Shoot()
    {
        switch (MyElement)
        {
            //Floats forward and up a bit, acts as a platform
            case Element.NONE:
                break;
            //Flies forward and is affected by gravity, Hits surfaces and can ignite surfaces
            case Element.FIRE:
                break;
            //Flies Straight and uneffected by gravity, Creates a block that can be jumped on the far end
            case Element.ICE:
                break;
            //It has a VERY heavy arc... that then Travels along the ground
            case Element.WATER:
                break;
            //High Force, Fast stop, Heavy, and busts stuff down
            case Element.EARTH:
                break;
            //Shoves stuff
            case Element.AIR:
                //Able to pick up ANY object
                break;
            //Bounces 3 times
            case Element.ELECTRIC:
                break;
            default:
                break;
        }
    }

}
