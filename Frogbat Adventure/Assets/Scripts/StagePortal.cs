using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePortal : MonoBehaviour
{
    // Start is called before the first frame update
    public string MyStage;
    BoxCollider2D MyCollider;
    Animator MyAnim;

    void Awake()
    {
        if(MyCollider == null)
        {
            MyCollider = GetComponent<BoxCollider2D>();
            MyCollider.enabled = false;
        }
        if(MyAnim == null)
        {
            MyAnim = GetComponent<Animator>();
            MyAnim.enabled = true;
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

    public void EnableCollider()
    {
        MyCollider.enabled = true;
        if (GetComponent<AnimController>() != null) GetComponent<AnimController>().ForceTrigger(AnimTriggers.Action2);
        else Debug.LogWarning("There is no Animator Controller");
    }
}
