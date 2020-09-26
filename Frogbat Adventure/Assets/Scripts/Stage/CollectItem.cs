using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollectItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public CollectibleType MyType;

    [SerializeField]
    public StagePortal Portal;

    [SerializeField]
    public SecretBlessing MyElement;

    [SerializeField]
    public int AbilitySlot;

    [SerializeField]
    public Ability MyAbility;

    [SerializeField]
    public int AuxNumber;


    [SerializeField]
    GameObject FollowTarget;
    float followDistance;
    bool FoundLock = false;

    private void Awake()
    {
        Debug.Log(Portal) ;
    }

    private void FixedUpdate()
    {
        if (FoundLock == false)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, followDistance * Mathf.Abs(transform.localScale.x));
            foreach (Collider2D obj in colliders)
            {
                if (obj.GetComponent<ToggleButton>().GetButtonType() == ButtonType.KeyLocked)
                {
                    FollowTarget = obj.gameObject;
                    followDistance = 0;
                    FoundLock = true;
                }
            }
        }

        if (FollowTarget != null && Vector2.Distance(transform.position, FollowTarget.transform.position) < followDistance)
        {
            transform.position = Vector2.Lerp(transform.position, FollowTarget.transform.position, 0.1f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == GameTags.Player.ToString())
        switch (MyType)
        {
            case CollectibleType.KEYS:
                    //This is commanding the Collectible To start its pickup animation and put itself relative to the parent... Subject to change
                    #region Old
                    /*
                    if (GetComponent<AnimController>() != null)
                    {
                        transform.parent.parent = collision.transform;
                        transform.parent.localPosition = new Vector2(0, 0.5f);
                        GetComponent<AnimController>().ForceTrigger(AnimTriggers.EXMovement);
                    }
                //Then since you're a key, Toggle the Portal to turn on.
                if (Portal != null)Portal.ToggleOn();
                else { Debug.LogWarning("This Key does not have a portal to target"); }
                    //Destruction is handled with the end of the animation.
                    //Destroy(this.gameObject);
                    */
                    #endregion

                    break;
            case CollectibleType.TEMPSHOT:
                    AbilitySlot = Mathf.Clamp(AbilitySlot, 0, 2);
                    AuxNumber = Mathf.Clamp(AuxNumber, 0, 200);
                    collision.GetComponent<ActionInput>().SetTempAbility(AbilitySlot,MyAbility,AuxNumber);
                break;
            case CollectibleType.SHOTOVERRIDE:
                    AbilitySlot = Mathf.Clamp(AbilitySlot, 0, 2);
                    AuxNumber = Mathf.Clamp(AuxNumber, 0, 200);
                    collision.GetComponent<ActionInput>().OverrideBaseShot(AbilitySlot, MyAbility, AuxNumber);
                    break;
            case CollectibleType.POWERUP:
                    break;
            case CollectibleType.COLLECTIBLE:
                    //So if it's a collectible it needs to talk to the Game Manager and tell it to update the current stage. 
                    break;
            default:
                Debug.Log("What the heck?");
                break;
        }
    }

    public CollectibleType GetCollectType()
    {
        return MyType;
    }
}
