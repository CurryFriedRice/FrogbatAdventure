using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBtn : MonoBehaviour
{
    //Used to just grab some of the variables.... May also incorperate a Zoom feature
    public CameraBoundsTrigger CameraVars;
    public GameObject PixelRepresentation;
    public D_StageData Data;

    private void Awake()
    {
           
    }

    void SetCameraBounds()
    {
        FindObjectOfType<CameraController>().SetVariables(CameraVars.NewType, PixelRepresentation, CameraVars.NewBounds, CameraVars.ExtraOffset, CameraVars.FollowSpeed);
        FindObjectOfType<CameraController>().SetZoom(CameraVars.Zoom);
    }

    //The button Calls this when the button is pressed, it'll hand in the stage data scriptable Object
    public void LoadStage()
    {
        FindObjectOfType<GameManager>().StageMan.LoadStage(Data);
    }
}
