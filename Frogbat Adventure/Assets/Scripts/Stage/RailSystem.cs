using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class RailSystem : MonoBehaviour
{

    public RailType Rail = RailType.OneWay;

    public GameObject AnchorParent;
    List<RailAnchor> AnchorList = new List<RailAnchor>();
    
    
    //public RailPlacement Placement = RailPlacement.Even;
    public GameObject RiderParent;
    List<RailRider> RiderList = new List<RailRider>();


    public GameObject RailSpriteParent;
    public SpriteRenderer RailPrefab;

    public bool CreateRiders;
    public RailRider RiderPrefab;
    public float PlaceDistance; 
    float TotalDistance = 0;
    // These should be placed at the 0 position for best results
    // Start is called before the first frame update
    
    void Awake()
    {
        //Debug.Log(AnchorParent.GetComponentsInChildren<RailAnchor>());
        foreach (RailAnchor Anchor in AnchorParent.GetComponentsInChildren<RailAnchor>())
        {
            //Debug.Log(Anchor.name);
            //So if the anchor isn't already in the list ADD IT
            if (!AnchorList.Contains(Anchor)) AnchorList.AddRange(GetComponentsInChildren<RailAnchor>());
            //if(Anchor.transform == this.transform) AnchorLocations.Remove(this.transform);      

           
        }
        
        //Setup for stuff linking Anchors Together
        bool first = true;
        RailAnchor PreviousAnchor = null;
        RailAnchor CurrentAnchor = null;
        
        foreach (RailAnchor Anchor in AnchorList)
        {
            //If we're at index 0 we set the current location to index 0
            if (first) 
            {
                Anchor.Previous = null;
                CurrentAnchor = Anchor;
                first = !first;
            }
            else
            {
                //So we update the positions
                PreviousAnchor = CurrentAnchor;
                CurrentAnchor = Anchor;

                PreviousAnchor.Next = CurrentAnchor;
                CurrentAnchor.Previous = PreviousAnchor;

                Vector3 Pos1 = PreviousAnchor.transform.position;
                Vector3 Pos2 = CurrentAnchor.transform.position;

                TotalDistance += Vector2.Distance(Pos1,Pos2);
                GenerateRail(Pos1, Pos2);
            }
            //Debug.Log(TotalDistance);
        }

        
        //So if it's a loop type we have to take the 0 and 
        if(Rail == RailType.Loop)
        {
            PreviousAnchor = CurrentAnchor;
            CurrentAnchor = AnchorList.ElementAt<RailAnchor>(0);

            PreviousAnchor.Next = CurrentAnchor;
            CurrentAnchor.Previous = PreviousAnchor;

            GenerateRail(PreviousAnchor.transform.position, CurrentAnchor.transform.position);
        }


        //This is not exactly going to be used often.....
        if (CreateRiders)
        {

        }
        else
        {
            foreach (RailRider Rider in RiderParent.GetComponentsInChildren<RailRider>())
            {
                Rider.RailSys = this;
                RiderList.Add(Rider);
            }
        }

        //StartCoroutine(AngleCheck());
    }
    /*
    IEnumerator AngleCheck()
    {
        yield return new WaitForSeconds(1);
        Vector3 Pos1 = AnchorLocations.ElementAt<RailAnchor>(0).transform.position; 
        Vector3 Pos2 = AnchorLocations.ElementAt<RailAnchor>(1).transform.position;
        
        Debug.Log(AngleFrom2Pos(Pos1,Pos2));
        StartCoroutine(AngleCheck());
        
    }
    */

    float AngleFrom2Pos(Vector3 Pos1, Vector3 Pos2)
    {
        return Mathf.Atan2(Pos2.y - Pos1.y, Pos2.x - Pos1.x) * Mathf.Rad2Deg;
    }

    void GenerateRail(Vector3 PreviousLocation, Vector3 CurrentLocation)
    {
        //This Is the Position in the middle
        Vector3 MiddlePosition = new Vector3((PreviousLocation.x + CurrentLocation.x) / 2,
                                             (PreviousLocation.y + CurrentLocation.y) / 2,
                                             (PreviousLocation.z + CurrentLocation.z) / 2);
        //The Angle that the rail should be to connect with the next rail
        //float zAngle = Mathf.Abs(AngleFrom2Pos(PreviousLocation, CurrentLocation));
        float zAngle = AngleFrom2Pos(PreviousLocation, CurrentLocation) % 180;
        Vector3 Angle = new Vector3(0, 0, zAngle);
        //Pythagorean theorom to figure out how long the rail should be.
        float xSquared = Mathf.Pow(PreviousLocation.x - CurrentLocation.x, 2);
        float ySquared = Mathf.Pow(PreviousLocation.y - CurrentLocation.y, 2);
        float Length = Mathf.Sqrt(xSquared + ySquared) + 0.5f;

        SpriteRenderer  Rail = Instantiate(RailPrefab, RailSpriteParent.transform);
        Rail.size = new Vector2(Length, 0.5f);
        Rail.transform.position = MiddlePosition;
        Rail.transform.eulerAngles = Angle;
        if (!isBetween(zAngle, -90, 90)) Rail.transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        
    }

    bool isBetween(float value, float low, float high)
    {
        float min = Mathf.Min(low, high), max = Mathf.Max(low, high);
        if(value >= min && value <= max) return true;
        return false;
    }

    public RailAnchor GetClosestNode(Transform Other)
    {
        RailAnchor retVal = null;
        if (AnchorList.Count<RailAnchor>() == 0) { return retVal; }

        retVal = AnchorList.ElementAt<RailAnchor>(0);

        foreach (RailAnchor Anchor in AnchorList) 
        {
            if(Other == null)
            {
                retVal = Anchor;
            }
            else if (Vector3.Distance(Other.position, Anchor.transform.position) < Vector3.Distance(Other.position, retVal.transform.position))
            {
                retVal = Anchor;
            }
        }
        return retVal;
    }

    public RailAnchor GetNode(ref RailAnchor CurrentAnchor, ref bool ReachedEnd)
    {
        if (AnchorList.Count<RailAnchor>() == 1) return AnchorList.ElementAt<RailAnchor>(0);
        if (CurrentAnchor == null) 
        {
            Debug.Log("Our anchors are null...?");
            return CurrentAnchor; 
        }
        switch (Rail)
        {
            case RailType.OneWay:
                if (ReachedEnd)
                {
                    ReachedEnd = true;
                    return CurrentAnchor;
                }
                if (!AnchorList.Contains(CurrentAnchor.Next)) ReachedEnd = true;
                return CurrentAnchor.Next;
                
            case RailType.Rubberband:
                if(ReachedEnd == true)
                {
                    if (CurrentAnchor.Previous == null)
                    {
                        ReachedEnd = false;
                        return CurrentAnchor;
                    }
                    return CurrentAnchor.Previous;
                }
                else
                {
                    if (CurrentAnchor.Next == null)
                    {
                        ReachedEnd = true;
                        return CurrentAnchor;
                    }
                    return CurrentAnchor.Next;
                }
            case RailType.Loop:
                return CurrentAnchor.Next;
                
            case RailType.UnitActivated:
            default:
                return null;
                
        }
        
    }

    /*
    public Vector3 GetNodePosition(int Node)
    {
        return AnchorLocations.ElementAt<Transform>(Node).position;
    }
    */
    
}
