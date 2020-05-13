using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealArea : MonoBehaviour
{
    public GameObject[] NextTileSet;
    public GameObject[] TileToHide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //We can do instancing to swap maps
            foreach(GameObject Target in NextTileSet)
                Target.SetActive(true);
            foreach (GameObject Target in TileToHide)
                Target.SetActive(false);
        }

    }

}
