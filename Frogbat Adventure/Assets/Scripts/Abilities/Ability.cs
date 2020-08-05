using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{ 
    public virtual void Activate()
    {
        Debug.Log("This is a " + this.name);
    }

    public virtual void SetObject(GameObject NewAbility) 
    {
     
    }

}
