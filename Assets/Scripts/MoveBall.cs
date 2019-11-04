﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : Move
{
    float decider_x,decider_y;
    CapsuleCollider2D x_col, y_col;
    // Start is called before the first frame update
    protected override void Start()
    {
        //CapsuleCollider2D[] temp = GetComponents<CapsuleCollider2D>();
        //if (temp[0].direction == CapsuleDirection2D.Vertical)
        //{
        //    y_col = temp[0];
        //    x_col = temp[1];
        //}
        //else
        //{
        //    y_col = temp[1];
        //    x_col = temp[0];
        //}
        bumper = GetComponent<Rigidbody2D>();
        decider_x = (float)sign.plus;
        decider_y = decider_x;
        ActualPosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBumper();
        ActualPosition();
    }

    protected override void MoveBumper(float sign = 1.0f)
    {
        bumper.transform.position = new Vector2(x + (speed * decider_x), y + (speed * decider_y));
        //bumper.AddForce(new Vector2(0.5f * sign, 0.5f * sign));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // bumper.gravityScale = -bumper.gravityScale;
        //if (ball.transform.position.y <= other.transform.position.y)
        CapsuleCollider2D temp = (CapsuleCollider2D)collision.otherCollider;
        
            if(temp.direction == CapsuleDirection2D.Horizontal)
            decider_x = -decider_x;
        //if (ball.transform.position.x <= other.transform.position.x)
            if (temp.direction == CapsuleDirection2D.Vertical)
            decider_y = -decider_y;
    }

    override protected void ActualPosition()
    {
        x = bumper.transform.position.x;
        y = bumper.transform.position.y;
    }
}
