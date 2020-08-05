using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bubble : BaseProjectile
{
    public Animator myAnim;
    public float SpeedDecayRate;
    public float DestructionTime;
    //public Vector2 Direction;
    
    bool DestructionStarted = false;



    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        //if (myRb == null) myRb = GetComponent<Rigidbody2D>();
        Bubble[] OtherBubbles =FindObjectsOfType<Bubble>();
        if (OtherBubbles.Length > 0)
        {
            
            int i = 0;
            while (i < OtherBubbles.Length)
            {
                if(OtherBubbles[i].gameObject == this.gameObject)
                {
                    Debug.Log("Hey I Found me at: " + OtherBubbles.Length);
                }else
                {
                    OtherBubbles[i].RemoteDestroy();
                }
                i++;
            }
        }
    }
    
    protected override void Shoot()
    {
        //base.Shoot();
            
        transform.position += AngledDirection * Speed * Time.deltaTime;
        //Speed = Mathf.Lerp(Speed, 0, 0.1f);
        
        float newX = Mathf.Lerp(AngledDirection.x, 0, SpeedDecayRate*1.5f);
        float newY = Mathf.Lerp(AngledDirection.y, 0, SpeedDecayRate);
        
       

        AngledDirection = new Vector2(newX, newY);
        //if (Speed < 0.25 && !DestructionStarted) StartCoroutine(DelayDestroy());
        if (Mathf.Abs(newX) < 0.1f && !DestructionStarted) StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        DestructionStarted = true;
        while(DestructionTime > 0)
        {
            if (!GlobalVar.PAUSED)
            {
                DestructionTime -= Time.deltaTime;
                yield return new WaitForSeconds(Time.deltaTime);
                //Debug.Log(DestructionTime);
            }
        }
        DestroyThis();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("I've Collided With" + collision.transform.name);
        //Speed *= -1;
        AngledDirection = new Vector2(-AngledDirection.x, AngledDirection.y);
    }

    public override void NormalizeFields()
    {
        base.NormalizeFields();
        AngledDirection = new Vector2((1f *MyOrigin.transform.localScale.x)+ AngledDirection.x, 0.5f + AngledDirection.y);
    }

    public void RemoteDestroy()
    {
        DestroyThis();
    }
}
