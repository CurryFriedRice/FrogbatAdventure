using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UI_Scroller : MonoBehaviour
{

    //So this puts UI Elements on the screen based off of 
    public RectTransform ScrollPanel, SelectedItem;
    public RectTransform BottomLeft, TopRight;

    public float ItemHeight;
    public float ItemWidth;
    public Vector2 Padding;

    public float StepSize;
    public Vector2 SlideSpeed;
    Camera MainCam;
 
    private void Update()
    {

    }

    private void Awake()
    {
        //Debug.Log(Screen.width);
        //S = GetComponent<RectTransform>();
        if (MainCam == null) MainCam = Camera.main;
        //StartCoroutine(PixelWidth());
        //MinOffset = MainCam.ScreenToViewportPoint(BottomLeft.transform.position);
        //MaxOffset = MainCam.ScreenToViewportPoint(TopRight.transform.position);
        //MidOffset = MainCam.ViewportToScreenPoint(Middle.transform.position);
        //Debug.Log(MainCam.ScreenToViewportPoint(BottomLeft.transform.position) + "=====" + MainCam.ScreenToViewportPoint(TopRight.transform.position));
        //Debug.Log(BottomLeft.position);
        //Debug.Log(BottomLeft.position);
    }

    //If this were equipment then we would make make item slots ft Sprite
    
    public void CheckPosition(RectTransform ItemPosition) 
    {
        //Vector3 ItemPos = MainCam.ScreenToViewportPoint(ItemPosition);
        //Debug.Log(BottomLeft.position + "=====" + TopRight.position+ "=====" + ItemPosition.position);
        SelectedItem = ItemPosition; 
        
        if (SelectedItem.position.y < BottomLeft.position.y + (Padding.y + ItemHeight) || 
            SelectedItem.position.y > TopRight.position.y   - (Padding.y + ItemHeight) ||
            SelectedItem.position.x < BottomLeft.position.x + (Padding.x + ItemWidth)  ||
            SelectedItem.position.x > TopRight.position.x   - (Padding.x + ItemWidth)
            )
        {
            //Debug.Log("This item is out of the mask");
            //StopAllCoroutines();
            //StartCoroutine(MoveScrollPanel());
            //Debug.Log("Hey this is out of bounds");
            StartCoroutine(MoveScrollPanel());
            Debug.Log("this is offscreen:" + ItemPosition.name);
        }
       
        //StartCoroutine(MoveTowards(ItemPosition));
    }

    IEnumerator MoveScrollPanel()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        Vector3 MovingTo = Vector3.zero;
        if(SelectedItem.position.y < BottomLeft.position.y + (ItemHeight))
        {
            MovingTo += new Vector3(0, SlideSpeed.y);
            //MovingTo += new Vector2(0, Mathf.Infinity);
        }
        else if (SelectedItem.position.y > TopRight.position.y - (ItemHeight))
        {
            MovingTo += new Vector3(0, -SlideSpeed.y);
            //MovingTo += new Vector2(0, -Mathf.Infinity);
        }

        if (SelectedItem.position.x < BottomLeft.position.x)
        {
            MovingTo += new Vector3(SlideSpeed.x, 0);
            //MovingTo += new Vector2(Mathf.Infinity, 0);
        }
        else if (SelectedItem.position.x > TopRight.position.x)
        {
            MovingTo += new Vector3(-SlideSpeed.x, 0);
            //MovingTo += new Vector2(Mathf.Infinity, 0);
        }

        //MovingTo += new Vector2((TopRight.position.x + BottomLeft.position.x) / 2, 0);
        //ScrollPanel.position = Vector2.MoveTowards(ScrollPanel.position, MovingTo, StepSize);
        ScrollPanel.position += MovingTo;

        Debug.Log("=====" + MovingTo + "\n=====" + TopRight.position.y + "\n=====" + BottomLeft.position.y);
        if (MovingTo != Vector3.zero) StartCoroutine(MoveScrollPanel());
    }
    
    IEnumerator MoveVertical()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        ScrollPanel.position = new Vector2(ScrollPanel.position.x + 0f, ScrollPanel.position.y + ItemHeight);
        if (SelectedItem.position.y < BottomLeft.position.y) { 
            //ScrollPanel.position = Vector3.MoveTowards(ScrollPanel.position);
        }
    }

    IEnumerator MoveHorizontal(Vector2 Pos)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        //So we have an X Slide and a Y Slide....

     //   rectTransform.position = Vector2.MoveTowards(rectTransform.position, Pos, SlideSpeed);
     //   if (rectTransform.position != new Vector3(Pos.x,Pos.y,0)) StartCoroutine(MoveTowards());
    }
 
}
