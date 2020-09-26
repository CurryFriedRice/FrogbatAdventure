using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjects : MonoBehaviour
{
    public List<CheckpointTrigger> Checkpoints;
    public List<GameObject> Collectibles;


    private void Start()
    {
        FindObjectOfType<GameManager>().SetGameState(GameState.GAMEPLAY);
        FindObjectOfType<GameManager>().StageMan.SetStageObjects(GetComponent<StageObjects>());
        FindObjectOfType<GameManager>().SaveFile();
    }


    
}
