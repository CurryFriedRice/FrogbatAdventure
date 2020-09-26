using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[System.Serializable]
public class Toggleable : MonoBehaviour, IToggleable
{
    public ToggleType Type;
    public bool Toggled;

    //Variables that need to be toggled....
    AnimController Anim;


    public int ColliderHeight = 3;
    public float Rate = 1;
    public BoxCollider2D Collider;
    public SpriteRenderer Sprite;
    public float Delay;
    void Awake()
    {
        if (Anim == null) Anim = GetComponent<AnimController>();
       

        if (Toggled)
        {
            Anim.ForceLayer(1);
            Anim.ForceTrigger(AnimTriggers.Action2);
            if (Collider != null) Collider.enabled = true;
        }
        else
        {
            Anim.ForceLayer(0);
            Anim.ForceTrigger(AnimTriggers.Action1);
            if (Collider != null) Collider.enabled = false;
        }

        if (Collider != null & Type == ToggleType.Effector)
        {
            Collider.size = new Vector2(Collider.size.x, ColliderHeight);
            Collider.offset = new Vector2(0, ColliderHeight / 2);
            Sprite = Collider.GetComponent<SpriteRenderer>();
            if(Toggled)Sprite.size = new Vector2(1, ColliderHeight);
            else Sprite.size = new Vector2(0,0);
        }
    }


    public void Toggle()
    {
        Toggled = !Toggled;

        if (Toggled) ToggleOn();
        else ToggleOff();
        //throw new System.NotImplementedException();
    }

    public void ToggleOff()
    {

        if (Anim != null) UpdateAnim(AnimTriggers.Action1, 0);
        if (Collider != null)
        {
            switch (Type)
            {
                case ToggleType.Effector:
                    StopAllCoroutines();
                    StartCoroutine(ToggleEffector(false));
                    break;
                case ToggleType.Collider:
                    UpdateCollider(false);
                    break;
                case ToggleType.Animator:
                case ToggleType.GameObject:
                default:
                    UnityEngine.Debug.LogWarning("What Am I Trying to Toggle?");
                break;
            }
        }
        //throw new System.NotImplementedException();
    }

    public void ToggleOn()
    {
        if (Anim != null) UpdateAnim(AnimTriggers.Action2, 1);
        if (Collider != null) 
        {
            switch (Type)
            {
                case ToggleType.Effector:
                    StopAllCoroutines();
                    StartCoroutine(ToggleEffector(true));
                    break;
                case ToggleType.Collider:
                    UpdateCollider(true);
                    break;
                case ToggleType.Animator:
                case ToggleType.GameObject:
                default:
                    UnityEngine.Debug.LogWarning("What Am I Trying to Toggle?");
                    break;
            }
        }
        //throw new System.NotImplementedException();
    }
    
    IEnumerator ToggleEffector(bool Active)
    {

        bool Finish = false;
        float currentHeight;
        if (Active)
        {
            currentHeight = 0;
            Collider.enabled = true;
            Sprite.enabled = true;
        }
        else
        {
            currentHeight = ColliderHeight;
        }

        while (!Finish)
        {
            if (Active)
            {
          
                UpdateEffector(ref currentHeight, Active, Rate);
                if (currentHeight >= ColliderHeight) 
                { 
                    Finish = true; 
                }
            }
            else
            {
                UpdateEffector(ref currentHeight, Active, -Rate);
                if (currentHeight <= 0)
                {
                    Finish = true;
                    Collider.enabled = false;
                    Sprite.enabled = false;
                }
            }
            yield return new WaitForSeconds(Delay);
        }
        //UnityEngine.Debug.Log("Finished");
    }

    void UpdateEffector(ref float _Height, bool _Active, float _Rate)
    {
        _Height += _Rate;
        Collider.size = new Vector2(1, _Height);
        Collider.offset = new Vector2(0, _Height / 2);
        if (Sprite != null) Sprite.size = new Vector2(1, _Height);
        if (_Active) { Collider.transform.localPosition = Vector2.zero; }
        else Collider.transform.localPosition = new Vector2(0, ColliderHeight - _Height);
    }

    void UpdateAnim(AnimTriggers NextState, float IdleLayer)
    {
        Anim.ForceLayer(IdleLayer);
        Anim.ForceTrigger(AnimTriggers.ToIdle);
        Anim.ForceTrigger(NextState);
    }

    void UpdateCollider(bool value)
    {
        Collider.enabled = value;
    }
}
