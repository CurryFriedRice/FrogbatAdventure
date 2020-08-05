using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class P_AnimController : MonoBehaviour
{

    Animator anim;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (anim == null) anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTriggers(P_AnimTriggers AnimTrigger)
    {
        anim.SetTrigger(AnimTrigger.ToString());
    }

    public void UpdateBools(P_AnimTriggers AnimTrigger, bool State)
    {
        anim.SetBool(AnimTrigger.ToString(), State);
    }


    //FORCED calls for events and in the animator
    public void MoveVertical()
    {
        anim.SetBool("IsGrounded", true);
        anim.SetBool("IsFloating", false);
    }

    public void HitGround()
    {
        anim.SetBool("IsGrounded", true);
        anim.SetBool("IsFloating", false);
    }

    private void StopGrounded()
    {
        anim.SetBool("IsGrounded", false);
    }

    private void StartFloating()
    {
        anim.SetBool("IsFloating", false);
    }

    public void AnimInputter(AnimationEvent MyEvent)
    {
        Debug.Log(MyEvent);
    }
}
