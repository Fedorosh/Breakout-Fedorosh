﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBumpers : Move
{
    //public Rigidbody2D ball;
    
    // Update is called once per frame
    void Update()
    {
        if (x > (-borders) && x < borders)
        {
            if (Input.GetKey("right") && !Input.GetKey("left"))
            {
                MoveBumper((float)sign.plus);
            }

            if (Input.GetKey("left") && !Input.GetKey("right"))
            {
                MoveBumper((float)sign.minus);
            }
        }
        if (x < -borders)
            MakeToWall((float)-borders);
        if (x > borders)
            MakeToWall((float)borders);

        ActualPosition();

    }

    void MakeToWall(float f)
    {
        bumper.transform.position = new Vector2(f, y);
    }
}