using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{

    public ToggleManager Manager;

    public ButtonType Type;
    //OneTime, Toggle, Weighted, Timed
    bool Toggled = false;

    public bool Timed = false;
    public float DelayTime;
    public AnimController Anim;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActionInput Activator = collision.GetComponent<ActionInput>();
        switch (Type)
        {
            case ButtonType.OneTime:
            case ButtonType.Toggle:
                if (Activator!= null) 
                {
                    Activator.SetToggleTarget(this);
                }
                break;
            case ButtonType.Weighted:
                Toggled = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ActionInput Activator = collision.GetComponent<ActionInput>();
        switch (Type)
        {
            case ButtonType.OneTime:
            case ButtonType.Toggle:
                if (Activator != null)
                {
                    Activator.SetToggleTarget(this);
                }
                break;
            case ButtonType.Weighted:
                Toggled = false;
                break;
            default:
                break;
        }
    }


    public void Activate()
    {
        switch (Type)
        {
            case ButtonType.OneTime:
                Toggled = true;
                TellManager();
                if (Timed)
                {
                    StopAllCoroutines();
                    StartCoroutine(TimedToggle(DelayTime));
                }
                break;
            case ButtonType.Toggle:
                Toggled = !Toggled;
                TellManager();
                if (Timed && Toggled)
                {
                    StopAllCoroutines();
                    StartCoroutine(TimedToggle(DelayTime));
                }
                break;
            case ButtonType.Weighted:
                Toggled = true;
                break;
            default:
                break;
        }
    }

    void TellManager()
    {
        Manager.UpdateToggle();
    }

    
    IEnumerator TimedToggle(float Timer)
    {
        float Delay = Timer;
        while (Delay > 0)
        {
            if (!GlobalVar.PAUSED)
            {
                float dt = Time.deltaTime;
                Delay -= dt;
                yield return new WaitForSeconds(dt);
            }
        }
        Toggled = false;
        TellManager();
    }

    public bool GetToggled()
    {
        return Toggled;
    }
}
