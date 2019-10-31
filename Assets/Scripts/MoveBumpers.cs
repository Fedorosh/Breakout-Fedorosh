using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBumpers : Move
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log(kamera.orthographicSize);

        if (x > -10.4 && x < 10.4)
        {
            if (Input.GetKey("right") && !Input.GetKey("left"))
                MoveBumper((float)sign.plus);

            if (Input.GetKey("left") && !Input.GetKey("right"))
                MoveBumper((float)sign.minus);
        }


        if (x < -10.4)
            MakeToWall(-10.4f);
        if (x > 10.4)
            MakeToWall(10.4f);
        //else bumper.velocity = Vector2.zero;
        //Vector2 temp = transform.position;
        //temp.x += Input.GetKeyDown(KeyCode.RightArrow);
        //bumper.transform.position = new Vector2(actual_x + speed, y);

        ActualPosition();

    }

    void MakeToWall(float f)
    {
        bumper.transform.position = new Vector2(f, y);
    }
}
