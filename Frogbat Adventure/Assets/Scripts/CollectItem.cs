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
    public StagePortal Door;

    [SerializeField]
    public Element MyElement;


    [SerializeField]
    public int AbilitySlot;

    [SerializeField]
    public Ability MyAbility;

    [SerializeField]
    public int ShotCount;

    private void Awake()
    {
        Debug.Log(Door) ;
    }
    public void OpenDoor()
    {
        Door.EnableCollider();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == GameTags.Player.ToString())
        switch (MyType)
        {
            case CollectibleType.KEYS:
                    if (GetComponent<AnimController>() != null)
                    {
                        transform.parent.parent = collision.transform;
                        transform.parent.localPosition = new Vector2(0, 0.5f);
                        GetComponent<AnimController>().ForceTrigger(AnimTriggers.EXMovement);
                    }
                if (Door != null)Door.EnableCollider();
                else { Debug.LogWarning("This Key does not have a portal to target"); }
               
                    //Destroy(this.gameObject);
                break;
            case CollectibleType.TEMPSHOT:
                    AbilitySlot = Mathf.Clamp(AbilitySlot, 0, 2);
                    ShotCount = Mathf.Clamp(ShotCount, 0, 200);
                    collision.GetComponent<ActionInput>().SetTempAbility(AbilitySlot,MyAbility,ShotCount);
                break;
            case CollectibleType.SHOTOVERRIDE:
                    AbilitySlot = Mathf.Clamp(AbilitySlot, 0, 2);
                    ShotCount = Mathf.Clamp(ShotCount, 0, 200);
                    collision.GetComponent<ActionInput>().OverrideBaseShot(AbilitySlot, MyAbility, ShotCount);
                    break;
            case CollectibleType.POWERUP:
                break;
                
            default:
                Debug.Log("What the heck?");
                break;
        }
    }
}
