using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBumpers : Move
{

    public BoxCollider2D pool;
    Touch touch;

    // Update is called once per frame
    void Update()
    {
        //Keyboard controls for PC
        // if (Input.GetKey("right") && !Input.GetKey("left") && !isCollidedRight) MoveBumper((float)sign.plus);
        // if (Input.GetKey("left") && !Input.GetKey("right") && !isCollidedLeft) MoveBumper((float)sign.minus);

        // Debug.Log(Input.mousePosition);

        // if((Input.mousePosition.y > bumper.transform.position.y && bumper.transform.position.y > 0) || (Input.mousePosition.y < bumper.transform.position.y && bumper.transform.position.y < 0))
        // {
                    //Translation = Input.GetAxis("Mouse X");
                    // dotyk.
                    //if(Input.GetTouch(0) == null)
                    for(int i = 0; i < Input.touchCount; i++)
                    {
                        Vector3 bumperPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                        if ((bumperPosition.y > transform.position.y && transform.position.y > 0) || (bumperPosition.y < transform.position.y && transform.position.y < 0))
                        {
                            bumperPosition.y = transform.position.y;
                            bumperPosition.z = transform.position.z;
                            transform.position = bumperPosition;
                        }
                        // if(transform.position.y < bumperPosition.y && transform.position.y < 0)
                        // {
                        //     bumperPosition.y = transform.position.y;
                        //     bumperPosition.z = transform.position.z;
                        //     transform.position = bumperPosition;
                        // }
                    }
                    
                    
                    
                    

        // float constrain = (Math.Abs(Translation) > 4.0f) ? (Translation < 0) ? -4.0f : 4.0f : Translation;

        // if ((isCollidedLeft && Translation < 0) || (isCollidedRight && Translation > 0))
        //     bumper.transform.Translate(0, 0, 0);
        // else
        //     bumper.transform.Translate((constrain) * speed, 0, 0);


        // }

        // ActualPosition();

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
