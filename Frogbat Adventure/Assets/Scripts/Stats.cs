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
    

    public void GetHit(int DamageValue, LaunchType Launch, Vector2 LaunchVector)
    {
        //So if they get hit they will start a co routine
        if (DamageValue > 0 && !invulnerable)
        {
            Health -= DamageValue;
        }
        if (!invulnerable)
        {
            StopAllCoroutines();
            myCon.Launch(Launch, LaunchVector);
            StartCoroutine(InvulFrames());
        }
        
    }

    IEnumerator InvulFrames()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;
    }

}
