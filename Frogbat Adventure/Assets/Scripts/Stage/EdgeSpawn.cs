using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeSpawn : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public EdgeSpawn SpawnLoc;
    bool hasSpawned = false;
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
        if (SpawnLoc != null)
        if(collision.tag == "Player" && hasSpawned == false)
        {
            SpawnLoc.SpawnPlayer(collision.GetComponent<Rigidbody2D>().velocity);
            hasSpawned = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (SpawnLoc != null)
            if (collision.tag == "Player" && hasSpawned == true)
        {
            Destroy(collision.gameObject);
            hasSpawned = false;
        }
    }

    public void ResetSpawn()
    {
        hasSpawned = false;
    }


    public void SpawnPlayer(Vector2 Velocity)
    {
        GameObject player;
        player = Instantiate(PlayerPrefab, transform.localPosition,Quaternion.identity);
        player.gameObject.GetComponent<Rigidbody2D>().velocity = Velocity;
    }


}
