using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public int CheckpointNum;
    public bool ReUsable = false;
    bool isTriggered = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!isTriggered || ReUsable)
            {
                ActivateCheckpoint();
            }
        }
    }

    //So we activate the checkpoint and save the data
    public void ActivateCheckpoint()
    {
        isTriggered = true;
        FindObjectOfType<StageManager>().SetCheckpoint(CheckpointNum);
    }

    public void SpawnPlayer(CharacterController2D Character)
    {
        if(FindObjectOfType<CharacterController2D>() == null)
            Instantiate(Character, transform.GetChild(0).position, Quaternion.identity, null);
    }
}
