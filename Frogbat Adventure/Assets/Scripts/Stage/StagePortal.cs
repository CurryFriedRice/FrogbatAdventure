using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePortal : MonoBehaviour, IToggleable
{
    // Start is called before the first frame update
    public int StageExitNumber;
    public bool[] isSecretExit = new bool[] { false };

    List<GameObject> CollidedObj = new List<GameObject>();
    BoxCollider2D MyCollider;
    AnimController MyAnim;
    public bool Toggled = false;

    void Awake()
    {
        if(MyCollider == null)
        {
            MyCollider = GetComponent<BoxCollider2D>();
            MyCollider.enabled = false;
        }
        if(MyAnim == null)
        {
            MyAnim = GetComponent<AnimController>();
            MyAnim.enabled = true;

            if (Toggled) ToggleOn();
            else ToggleOff();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !CollidedObj.Contains(collision.gameObject)) 
        { 
            FinishStage();
            CollidedObj.Add(collision.gameObject);
        }
    }

    public void FinishStage()
    {
        //Debug.Log(SceneManager.GetSceneByName(MyStage));
        FindObjectOfType<GameManager>().StageMan.CompleteStage();
        FindObjectOfType<GameManager>().StageMan.UnlockStage(StageExitNumber);
        FindObjectOfType<GameManager>().StageMan.LoadStage(StageExitNumber);
     
    }

    public void Toggle()
    {
        throw new System.NotImplementedException();
    }

    public void ToggleOff()
    {
        MyCollider.enabled = true;
        if (MyAnim != null)
        {
            MyAnim.ForceTrigger(AnimTriggers.Action1);
            MyAnim.ForceTrigger(AnimTriggers.ToIdle);

        }
        else Debug.LogWarning("There is no Animator Controller");
        //throw new System.NotImplementedException();
    }

    public void ToggleOn()
    {
        
        MyCollider.enabled = true;
        if (MyAnim != null)
        {
            MyAnim.ForceTrigger(AnimTriggers.Action2);
            MyAnim.ForceTrigger(AnimTriggers.ToIdle);
        
        }
        else Debug.LogWarning("There is no Animator Controller");
        //throw new System.NotImplementedException();
    }

    
}
