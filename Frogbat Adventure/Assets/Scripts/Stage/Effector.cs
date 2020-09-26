using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    public float Strength;
    public bool EffectsGrounded;
    AnimController Anim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("ENTERED!");
        if (collision.tag == GameTags.Player.ToString())
        {
            if (Anim == null) Anim = GetComponent<AnimController>();
            if (Anim != null)
            {
                Anim.ForceTrigger(AnimTriggers.Action1);
                Anim.ForceTrigger(AnimTriggers.ToIdle);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("ENTERED!");
        if (collision.tag == GameTags.Player.ToString()) {
            collision.GetComponent<CharacterController2D>().Launch(LaunchType.EXTERNAL, transform.up * Strength, EffectsGrounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("EXITED!");
        if (collision.tag == GameTags.Player.ToString())
        {
            collision.GetComponent<CharacterController2D>().RemoveExternal(transform.up * Strength);
        }
        if (Anim == null) Anim = GetComponent<AnimController>();
        if (Anim != null) Anim.ForceTrigger(AnimTriggers.ToIdle);
    }
    
    
}
