using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected AIStates State = AIStates.Idle;
    public AnimController Anim;
    protected bool Active;

    // Start is called before the first frame update
    protected void Awake()
    {
        Active = true;
        if (Anim == null) Anim = GetComponent<AnimController>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (Active)
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
                    LogWarning(State.ToString() + " : State does not Exist");
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
