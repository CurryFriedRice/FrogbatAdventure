using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : EnemyAI
{
    public Ability Shooter;
    bool shoot = false;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    protected override void Idle()
    {
        if(!shoot) StartCoroutine(DelayShot());
    }

    protected override void Chase()
    {

    }

    protected override void Attack()
    {
        if(!shoot) Shooter.Activate();
        shoot = true;
    }

    protected override void Damaged()
    {

    }

    protected override void Death()
    {

    }

    IEnumerator DelayShot()
    {
        
        State = AIStates.Attack;
        yield return new WaitForSeconds(5);
        shoot = false;
     
    }
}