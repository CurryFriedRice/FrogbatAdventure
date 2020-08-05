using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stats : MonoBehaviour
{
    #region Variables
        CharacterController2D myCon;
        PlayerMovement myMove;
        P_AnimController myAnim;

        public int Health;
        public float invulTime = 1f;
        public bool invulnerable = false;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(GetComponent<CharacterController2D>() != null && GetComponent<PlayerMovement>()) {
            //Debug.Log("I am the player stats");
            myCon = GetComponent<CharacterController2D>();
            myMove = GetComponent<PlayerMovement>();
        }
        else
        {
            //Debug.Log("This isn't part of a player");   
        }
    }
    

    public void GetHit(int DamageValue, LaunchType Launch)
    {
        //So if they get hit they will start a co routine
        if (invulnerable == false)
        {
            myCon.Launch(Launch);
            Health -= DamageValue;
            StartCoroutine(InvulFrames());
        }
    }

    IEnumerator InvulFrames()
    {
        float currentTime = invulTime;

        invulnerable = true;
        //myAnim.setBool("Invul", true);

        while (currentTime > 0)
        {
            if (GlobalVar.PAUSED == false)
            {
                currentTime -= Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        invulnerable = false;
        //myAnim.setBool("Invul", false);

    }

}
