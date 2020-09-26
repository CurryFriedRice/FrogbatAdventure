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

    List<GameObject> Triggers = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (!Triggers.Contains(collision.gameObject))
        {
            Triggers.Add(collision. gameObject);
            switch (Type)
            {
                case ButtonType.OneTime:
                case ButtonType.Toggle:
                    ActionInput Activator = collision.GetComponent<ActionInput>();
                    if (Activator != null)
                    {
                        Activator.SetToggleTarget(this);
                        //Activator.SetToggleTarget(this, true);
                    }
                    break;
                case ButtonType.Weighted:
                    UpdateState(true);
                    TellManager();
                    break;
                case ButtonType.KeyLocked:
                    CollectItem Key = collision.GetComponent<CollectItem>();
                    if (Key != null)
                    {
                        UpdateState(true);
                        TellManager();
                    }
                break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (Triggers.Contains(collision.gameObject))
        {
            Triggers.Remove(collision.gameObject);
            switch (Type)
            {
                case ButtonType.OneTime:
                case ButtonType.Toggle:
                    ActionInput Activator = collision.GetComponent<ActionInput>();
                    if (Activator != null)
                    {
                        Activator.SetToggleTarget(this);
                        //Activator.SetToggleTarget(this, false);
                    }
                    break;
                case ButtonType.Weighted:
                    UpdateState(false);
                    TellManager();
                    break;
                case ButtonType.KeyLocked:
                    CollectItem Key = collision.GetComponent<CollectItem>();
                    if (Key != null)
                    {
                        UpdateState(false);
                        TellManager();
                    }
                    break;
                default:
                    break;
            }
        }
    }


    public void Activate()
    {
        switch (Type)
        {
            case ButtonType.OneTime:
                UpdateState(true);
                TellManager();
                if (Timed)
                {
                    StopAllCoroutines();
                    StartCoroutine(TimedToggle(DelayTime));
                }
                break;
            case ButtonType.Toggle:
                UpdateState();
                TellManager();
                if (Timed && Toggled)
                {
                    StopAllCoroutines();
                    StartCoroutine(TimedToggle(DelayTime));
                }
                break;
            case ButtonType.Weighted:
                UpdateState(true);
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
    
    void UpdateState() 
    {
        Toggled = !Toggled;
        if (Toggled) 
        {
            Anim.ForceLayer(1);
            Anim.ForceTrigger(AnimTriggers.ToIdle);
            Anim.ForceTrigger(AnimTriggers.Action2);
        }
        else 
        {
            Anim.ForceLayer(0);
            Anim.ForceTrigger(AnimTriggers.ToIdle);
            Anim.ForceTrigger(AnimTriggers.Action1);
        }
    }
    void UpdateState(bool value)
    {
        Toggled = value;
        if (Toggled)
        {
            Anim.ForceLayer(1);
            Anim.ForceTrigger(AnimTriggers.ToIdle);
            Anim.ForceTrigger(AnimTriggers.Action2);
        }
        else
        {
            Anim.ForceLayer(0);
            Anim.ForceTrigger(AnimTriggers.ToIdle);
            Anim.ForceTrigger(AnimTriggers.Action1);
        }
    }
    
    public ButtonType GetButtonType()
    {
        return Type;
    }

}
