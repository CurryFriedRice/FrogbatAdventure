using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    GameObject ChildrenOnBubble;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (collision.transform.position.y > transform.position.y)
            {
                collision.transform.SetParent(this.gameObject.transform, true);
                ChildrenOnBubble = collision.gameObject;
            }
        }
    }
    private void OnDestroy()
    {
    
            SetPlayerLeave();
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SetPlayerLeave();
        }
    }
    
    void SetPlayerLeave()
    {
        if (ChildrenOnBubble != null)
        {
            ChildrenOnBubble.transform.SetParent(null, true);
            ChildrenOnBubble.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //ChildrenOnBubble.gameObject.transform.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

}
