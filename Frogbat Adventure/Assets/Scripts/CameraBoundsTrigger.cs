using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsTrigger : MonoBehaviour
{
    public CameraType NewType = CameraType.STATIC;
    //So right now it's just two vectors... That may be hard to control so perhaps two transforms instead?
    public Vector2[] NewBounds = new Vector2[2];

    public Transform[] GameObjectPositions;
    public Vector2 ExtraOffset;
    public float FollowSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CameraController>().SetVariables(NewType, NewBounds, ExtraOffset, FollowSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag + " tagged item is trying to change camera");
        if(collision.GetComponent<CharacterController2D>() != null) FindObjectOfType<CameraController>().SetVariables(NewType, NewBounds, ExtraOffset, FollowSpeed); ;
    }
}
