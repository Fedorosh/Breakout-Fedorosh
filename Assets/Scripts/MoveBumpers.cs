using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class MoveBumpers : Move
{

    public BoxCollider2D pool;
    Touch touch;
    [SerializeField] MoveMover steer;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard controls for PC
        //if (Input.GetKey("right") && !Input.GetKey("left") && !isCollidedRight) MoveBumper((float)sign.plus);
        //if (Input.GetKey("left") && !Input.GetKey("right") && !isCollidedLeft) MoveBumper((float)sign.minus);

        if (steer.IsClicked)
                        {
                            Translation = CountTranslation(transform.position.x, steer.transform.position.x);
                                
                            transform.position = new Vector3(steer.transform.position.x,transform.position.y,transform.position.z);
                        }


    }
    
    private float CountTranslation(float x1, float x2)
    {
        return x1 > x2 ? -Math.Abs(x1 - x2) : Math.Abs(x1 - x2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "wallleft") isCollidedLeft = true;
        if (collision.collider.tag == "wallright") isCollidedRight = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "wallright" ) isCollidedRight = false;
        if (collision.collider.tag == "wallleft") isCollidedLeft = false;
    }
}
