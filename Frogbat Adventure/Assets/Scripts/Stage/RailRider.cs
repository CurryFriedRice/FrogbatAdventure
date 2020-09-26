using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class RailRider : MonoBehaviour, IToggleable
{
    public RailSystem RailSys;
    public RailAnchor CurrentNode = null;
    bool ReachedEnd;
    public bool Active = false;

    public bool NeedObject = false;

    // Start is called before the first frame update
    void Awake()
    {
        //So when the railRider is created 
        if (RailSys != null)
        {
            CurrentNode = RailSys.GetClosestNode(transform);
            //transform.position = RailSys.GetNode(CurrentNode, ref ReachedEnd);
            CurrentNode = RailSys.GetNode(ref CurrentNode, ref ReachedEnd);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RailSys == null || !Active || GlobalVar.PAUSED) { }
        else if (CurrentNode == null)
        {
            CurrentNode = RailSys.GetClosestNode(transform);
        }
        else
        {
            if (CurrentNode.Lerping)
            {
                //Debug.Log("Moving Towards: Node" + CurrentNode + " | " + TargetMoveTowards);
                transform.position = Vector2.Lerp(transform.position, CurrentNode.transform.position, CurrentNode.Speed);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, CurrentNode.transform.position, CurrentNode.Speed);
            }
            if (Vector2.Distance(transform.position, CurrentNode.transform.position) < 0.1f)
            {
                CurrentNode = RailSys.GetNode(ref CurrentNode, ref ReachedEnd);
                //Debug.Log("Get New Node: " + CurrentNode + " | " + TargetMoveTowards) ;
            }
       
     
        }

    }

    public void Toggle()
    {
        Active = !Active;
        //throw new System.NotImplementedException();
    }

    public void ToggleOn()
    {
        Active = true;
        //throw new System.NotImplementedException();
    }

    public void ToggleOff()
    {
        Active = false;
        //throw new System.NotImplementedException();
    }
}
