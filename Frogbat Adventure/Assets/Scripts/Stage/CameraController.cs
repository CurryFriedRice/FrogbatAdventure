using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraType MyCameraType = CameraType.STATIC;
    GameObject FollowTarget;

    //Index 0 is always Either Left or Above the player 
    //Index 1 is always Either Right or Below the player
    Vector2[] FollowBounds = new Vector2[2];
    public Vector2 ExtraOffset = Vector2.zero;
    public float CameraSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        //So if the Camera finds another audio listener... E.g. It's on a player, then the one on the camera will be turned off
        if (FindObjectsOfType<AudioListener>().Length > 1) GetComponent<AudioListener>().enabled = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //So depending on what the cameratype is do different things
        switch (MyCameraType)
        {
            case CameraType.STATIC:
                MoveStatic();
                break;
            case CameraType.HORIZONTAL:
                MoveHorizontal();
                break;
            case CameraType.VERTICAL:
                MoveVertical();
                break;
            case CameraType.FOLLOW:
                MoveFollow();
                break;
            case CameraType.RAILED:
            default:
                Debug.Log("Excuse me?!? What follow logic is the camera using");
                break;
        }        
}

    public void SetVariables(CameraType NewType, GameObject Target, Vector2[] NewBounds, Vector2 NewOffset, float NewSpeed)
    {
        FollowTarget = Target;
        MyCameraType = NewType;
        FollowBounds = NewBounds;
        ExtraOffset = NewOffset;
        CameraSpeed = NewSpeed;
    }

    public void SetZoom(float Zoom)
    {
        Camera MainCam = Camera.main;
        StopCoroutine("SetCameraSize");
        StartCoroutine(SetCameraSize(MainCam, Zoom));
    }

    IEnumerator SetCameraSize(Camera cam, float zoom)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, 0.1f);
        if (cam.orthographicSize != zoom) SetCameraSize(cam, zoom);
    }

    public void FindPlayer()
    {
        FollowTarget = FindObjectOfType<CharacterController2D>().gameObject;
    }

    public void SetCameraPosition(CameraType NewType)
    {
        MyCameraType = NewType;
    }

    void MoveStatic()
    {
        //It's static it doesn't move... Or more accurately It move twoards the one location it's told to
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(FollowBounds[0].x, FollowBounds[0].y, -10f), CameraSpeed);
    }

    void MoveHorizontal()
    {
        Vector2 PlayerPos = FollowTarget.transform.position;
        Vector3 NewCameraPosition;
        float xPosition = 0f;
        float yPosition = 0f;

        //So if the player is farther
        yPosition = FollowBounds[0].y;

        if (PlayerPos.x < FollowBounds[0].x) xPosition = FollowBounds[0].x;
        else if (PlayerPos.x > FollowBounds[1].x) xPosition = FollowBounds[1].x;
        else xPosition = PlayerPos.x;


        //we can grab either part of the X position... The X position will be static
        NewCameraPosition = new Vector3(xPosition + ExtraOffset.x, yPosition + ExtraOffset.y, -10f);
        //Vector2 Location = Vector2.Lerp(transform.position, NewCameraPosition, 0.1f);
        transform.position = Vector3.MoveTowards(transform.position, NewCameraPosition, CameraSpeed);
        //So we need to track the player's X position, and not care about the Y Position
        //So we need conditions to check when it's less than the left bound or greater than the right bound

    }

    void MoveVertical()
    {
        //Find Figure out the X position 

        Vector2 PlayerPos = FollowTarget.transform.position;
        Vector3 NewCameraPosition;
        float xPosition = 0f;
        float yPosition = 0f;

        //So if the player is farther
        if (PlayerPos.y > FollowBounds[0].y) yPosition = FollowBounds[0].y;
        else if (PlayerPos.y < FollowBounds[1].y) yPosition = FollowBounds[1].y;    
        else yPosition = PlayerPos.y;

        xPosition = FollowBounds[0].x;

        NewCameraPosition = new Vector3(xPosition + ExtraOffset.x, yPosition + ExtraOffset.y, -10f);

        //Vector2 Location = Vector2.Lerp(transform.position, NewCameraPosition, 0.1f);
        transform.position = Vector3.MoveTowards(transform.position, NewCameraPosition, CameraSpeed);
        //So we need to track the player's X position, and not care about the Y Position
        //So we need conditions to check when it's less than the left bound or greater than the right bound

    }

    void MoveFollow()
    {

        Vector2 PlayerPos = FollowTarget.transform.position;
        Vector3 NewCameraPosition;
        float xPosition = 0f;
        float yPosition = 0f;
        
        //So if the player is farther
        if (PlayerPos.y > FollowBounds[0].y) yPosition = FollowBounds[0].y;
        else if (PlayerPos.y < FollowBounds[1].y) yPosition = FollowBounds[1].y;
        else yPosition = PlayerPos.y;

        if (PlayerPos.x < FollowBounds[0].x) xPosition = FollowBounds[0].x;
        else if (PlayerPos.x > FollowBounds[1].x) xPosition = FollowBounds[1].x;
        else xPosition = PlayerPos.x;

        NewCameraPosition = new Vector3(xPosition + ExtraOffset.x, yPosition + ExtraOffset.y, -10f);

        transform.position = Vector3.MoveTowards(transform.position, NewCameraPosition, CameraSpeed);
        //So we need to track the player's X position, and not care about the Y Position
        //So we need conditions to check when it's less than the left bound or greater than the right bound

    }



}
