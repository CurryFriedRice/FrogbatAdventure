using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : BaseProjectile
{
    
    // Start is called before the first frame update
    void Start()
    {

        transform.localEulerAngles = (transform.parent.localEulerAngles * -1f);
        Debug.Log(transform.parent.name + "|" + transform.parent.right);

        //transform.localEulerAngles = transform.parent.eulerAngles * (-1f * transform.parent.localScale.x);
    }

    protected override void Shoot()
    {
        //base.Shoot();
        transform.position += new Vector3(transform.parent.right.x * transform.localScale.x, transform.parent.right.y, 0)*Time.deltaTime;
        //Debug.Log(transform.parent.right);
        //this.gameObject.transform.localScale.x * transform.right;
    }
    protected override void DestroyThis()
    {
        //base.DestroyThis();
        Destroy(transform.parent);
    }
}
