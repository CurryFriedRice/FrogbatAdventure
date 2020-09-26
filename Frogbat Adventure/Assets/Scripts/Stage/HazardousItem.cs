using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HazardousItem : MonoBehaviour
{
    public int DamageAmount;
    public float KnockbackMod = 1f;
    //public List<GameObject> HitTarget = new List<GameObject>();
    public LaunchType Launch = LaunchType.NONE;
    public ProjectileModifier HitBox = ProjectileModifier.None;
    

    private void OnCollisionStay2D(Collision2D collision)
    {

    }


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
        if (target == null) Debug.Log("UHHH TARGET HAS NO STATS!");
        else
        {
            Vector2 LaunchDirection = GlobalVar.KnockbackForce* KnockbackMod * Mathf.Sign(transform.position.x - target.transform.position.x);
            target.GetHit(DamageAmount, Launch, LaunchDirection);
        }
        Debug.Log("HONKADOOK CHECK THIS BOOT");
    }

}
