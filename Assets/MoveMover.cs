﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveMover : Button
{
    bool isClicked = false;
    // Start is called before the first frame update
    public override void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }
    public bool IsClicked {
        get {return isClicked;}
        set {isClicked = value;}
    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked)
        for(int i = 0; i < Input.touchCount; i++)
                    {
                        Vector3 bumperPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                        // if ((bumperPosition.y > transform.position.y && transform.position.y > 0) || (bumperPosition.y < transform.position.y && transform.position.y < 0))
                            bumperPosition.y = transform.position.y;
                            bumperPosition.z = transform.position.z;
                            transform.position = bumperPosition;

                        // if(transform.position.y < bumperPosition.y && transform.position.y < 0)
                        // {
                        //     bumperPosition.y = transform.position.y;
                        //     bumperPosition.z = transform.position.z;
                        //     transform.position = bumperPosition;
                        // }
                    }
    }

    private void DoSomething()
    {
        
        Debug.Log("works");
    }
}
