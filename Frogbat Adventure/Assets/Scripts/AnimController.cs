using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimController : MonoBehaviour
{

    public bool isRepeating = false;
    public float delayTime = 3f;
    public AnimTriggers[] Sequence;
    int SequenceStep = 0;

    //This thing is the thing that controls the Animator for ALL OBjects If it's animated it should have a controller.
    Animator MyAnim;
    
    private void Awake()
    {
        if (MyAnim == null) MyAnim = GetComponent<Animator>();
        if (isRepeating) StartCoroutine(ConstantTrigger());
    }

    // Update is called once per frame
    public bool BasicAnimTrigger(AnimTriggers Trigger)
    {
        Debug.Log(Trigger.ToString());
        switch (Trigger)
        {
            case AnimTriggers.Action1:
                MyAnim.SetTrigger("Variation1");
                return true;
            case AnimTriggers.Action2:
                MyAnim.SetTrigger("Variation2");
                return true;
            case AnimTriggers.Action3:
                MyAnim.SetTrigger("Variation3");
                return true;
            case AnimTriggers.ToIdle:
                MyAnim.SetTrigger("BackToIdle");
                return true;
            case AnimTriggers.EXMovement:
                MyAnim.SetTrigger("EXMovement");
                return true;
            default:
                Debug.Log("This isn't a recognized Trigger" + Trigger.ToString());
                return false;

        }
    }

    //Generic call just to set a trigger... Very Dangerous... but workable
    public void ForceTrigger(AnimTriggers Trigger)
    {
        if(MyAnim != null)
        {
            MyAnim.SetTrigger(Trigger.ToString());
        }
    }

    public void ForceLayer(float LayerFloat)
    {
        if (MyAnim != null)
        {
            MyAnim.SetFloat(AnimTriggers.IdleLayer.ToString(), LayerFloat);
        }
    }

    public IEnumerator ConstantTrigger()
    {
        MyAnim.SetTrigger(Sequence[SequenceStep].ToString());
        //MyAnim.SetTrigger(AnimTriggers.ToIdle.ToString());
        SequenceStep++;
        if (SequenceStep >= Sequence.Length) SequenceStep = 0;
        float delay = delayTime;
        //while (delay > 0) 
        //{
        //    float dt = Time.deltaTime;
            yield return new WaitForSeconds(delayTime);
        //    if (!GlobalVar.PAUSED)
        //   {
        //        delay -= dt;
        //    }
        //}
        StartCoroutine(ConstantTrigger());
    }


    public void RemoteDestroy()
    {
        Destroy(this.gameObject);
    }
}
