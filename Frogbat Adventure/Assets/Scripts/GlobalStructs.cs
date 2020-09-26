using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not used....
public struct RailAnchorData 
{
    public float Speed;
    public bool Lerping;

    public GameObject Previous;
    public GameObject Next;

    public RailAnchorData(float _speed, bool _lerping, GameObject _prev, GameObject _next)
    {
        Speed = _speed;
        Lerping = _lerping;
        Previous = _prev;
        Next = _next;
    }
}