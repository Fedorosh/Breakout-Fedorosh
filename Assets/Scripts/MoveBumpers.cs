using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBumpers : Move
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right") && !Input.GetKey("left") && !isCollidedRight) MoveBumper((float)sign.plus);

        if (Input.GetKey("left") && !Input.GetKey("right") && !isCollidedLeft) MoveBumper((float)sign.minus);

        Translation = Input.GetAxis("Mouse X");

        if ((isCollidedLeft && Translation < 0) || (isCollidedRight && Translation > 0))
            bumper.transform.Translate(0, 0, 0);
        else
            bumper.transform.Translate(Translation * speed, 0, 0);

        ActualPosition();

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
