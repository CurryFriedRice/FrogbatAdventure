using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected AIStates State = AIStates.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        switch (State)
        {
            case AIStates.Idle:
                Idle();
                break;
            case AIStates.Chase:
                Chase();
                break;
            case AIStates.Attack:
                Attack();
                break;  
            case AIStates.Damaged:
                Damaged();
                break;
            case AIStates.Dead:
                Death();
                break;
            defualt:
                break;
        }
    }

    protected virtual void Idle()
    {
        LogWarning(State.ToString());    
    }

    protected virtual void Chase()
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Damaged()
    {

    }

    protected virtual void Death()
    {

    }

    protected void LogWarning(string StateName)
    {
        Debug.LogWarning("The " + StateName + " state for " + name + " is not prepared");
    }

    public void RemoteDestroy()
    {
        Destroy(this.gameObject);
    }

}
