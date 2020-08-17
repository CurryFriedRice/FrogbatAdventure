using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : EnemyAI, IToggleable
{
    public Ability Shooter;
    bool Ready = true;
    public float DelayTime;

    protected override void FixedUpdate()
    {
        if(Active)
         base.FixedUpdate();
    }

    #region
    protected override void Idle()
    {
        if (Ready)
        {
            State = AIStates.Attack;
        }
    }

    protected override void Chase()
    {

    }

    protected override void Attack()
    {
        if (Anim != null && Ready)
        {
            Anim.ForceTrigger(AnimTriggers.Action1);
            Ready = false;
            StopAllCoroutines();
            StartCoroutine(DelayShot()); 
        }
    }

    protected override void Damaged()
    {

    }

    protected override void Death()
    {

    }
    #endregion

    IEnumerator DelayShot()
    {
        yield return new WaitForSeconds(DelayTime);
        Ready = true;
    }

    public void ShootWeapon()
    {
        Shooter.Activate();
    }

    public void Toggle()
    {
        Active = !Active;
    }

    public void ToggleOn()
    {
        throw new System.NotImplementedException();
    }

    public void ToggleOff()
    {
        Active = false;
        //throw new System.NotImplementedException();
    }
}