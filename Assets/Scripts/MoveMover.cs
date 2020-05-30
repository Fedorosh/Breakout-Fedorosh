using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveMover : Button
{
    bool isClicked = false;

    Vector3 bumperPosition;
    private int t;

    private MoveMover steer;

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

    protected override void Start()
    {
        base.Start();

        foreach (var x in GameObject.FindGameObjectsWithTag("steer"))
        {
            if (x.GetComponent<MoveMover>() != this)
                steer = x.GetComponent<MoveMover>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if(steer == this) Debug.Log("to ten sam");
        if (isClicked)
        //{
        {
            if (!steer.isClicked)
                bumperPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            else
                bumperPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);




            bumperPosition.y = transform.position.y;
            bumperPosition.z = transform.position.z;
            transform.position = bumperPosition;

        }
        //    t = Input.touchCount;
        //    if(t == 2)
        //        bumperPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
        //    if(t == 1)

        //}
        //for(int i = 0; i < Input.touchCount; i++)
        // {

        // if ((bumperPosition.y > transform.position.y && transform.position.y > 0) || (bumperPosition.y < transform.position.y && transform.position.y < 0))


        // if(transform.position.y < bumperPosition.y && transform.position.y < 0)
        // {
        //     bumperPosition.y = transform.position.y;
        //     bumperPosition.z = transform.position.z;
        //     transform.position = bumperPosition;
        // }
        //}
    }

    private void DoSomething()
    {
        
        Debug.Log("works");
    }
}
