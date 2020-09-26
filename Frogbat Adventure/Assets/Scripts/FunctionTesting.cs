using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        Debug.Log(resolutions.Length);

        int i = 0;
        // Print the resolutions
        foreach (var res in resolutions)
        {
            Debug.Log("SCREEN RESOLUTIONS " + i+ " : " + res.width + "x" + res.height + " : " + res.refreshRate);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
