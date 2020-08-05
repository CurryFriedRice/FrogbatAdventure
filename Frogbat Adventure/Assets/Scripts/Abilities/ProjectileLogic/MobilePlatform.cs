using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
            collision.transform.parent = this.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
        //Rebound();
    }
    
    void Rebound()
    {
        if (GetComponentInParent<Rigidbody2D>())
        {
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(GetComponentInParent<Rigidbody2D>().velocity.x, -1.5f);
        }
    }

    private void OnDestroy()
    {
        transform.DetachChildren();

    }
}
