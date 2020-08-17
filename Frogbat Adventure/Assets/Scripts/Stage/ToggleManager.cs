using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleManager : MonoBehaviour
{
   
    public List<GameObject> ToggleableObjects;
    public List<ToggleButton> Buttons;
    List<IToggleable> ListOfToggleables = new List<IToggleable>();

    public bool InitialState;
    bool CurrentState;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(ToggleButton btn in Buttons)
        {
            btn.Manager = this;
        }
        //var ss = FindObjectsOfType<MonoBehaviour>().OfType<IToggleable>();
    

        foreach(GameObject Toggle in ToggleableObjects)
        {
            ListOfToggleables.Add(Toggle.GetComponent<IToggleable>());
        }

        foreach (IToggleable Toggle in ListOfToggleables)
        {
            Debug.Log(Toggle);
        }
    }

    public void UpdateToggle()
    {
        Debug.Log(myState());
        foreach (IToggleable Item in ListOfToggleables)
        {
            Item.Toggle();
        }
    }


    bool myState()
    {
        bool NewState = InitialState;
        foreach(ToggleButton Button in Buttons)
        {
            if (Button.GetToggled()) NewState = !NewState;
        }
        return NewState;
    }

}
