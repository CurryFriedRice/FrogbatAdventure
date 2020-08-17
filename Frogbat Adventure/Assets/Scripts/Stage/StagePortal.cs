using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePortal : MonoBehaviour, IToggleable
{
    // Start is called before the first frame update
    public string MyStage;
    BoxCollider2D MyCollider;
    AnimController MyAnim;
    bool Toggled = false;

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

            if (Toggled) MyAnim.ForceTrigger(AnimTriggers.Action2);
            else MyAnim.ForceTrigger(AnimTriggers.Action1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")LoadStage();
    }

    public void LoadStage()
    {
        Debug.Log(SceneManager.GetSceneByName(MyStage));
        SceneManager.LoadScene(MyStage);
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
