using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    protected Rigidbody2D bumper;
    public float speed;
    protected float x;
    protected float y;
    protected enum sign : int { plus = 1, minus = -1 };
    public Camera kamera;

    protected virtual void Start()
    {
        bumper = GetComponent<Rigidbody2D>();
        ActualPosition();
        y = bumper.transform.position.y;
    }

    virtual protected void MoveBumper(float sign)
    {
        bumper.transform.position = new Vector2(x + (speed * sign), y);
    }
    virtual protected void ActualPosition()
    {
        x = bumper.transform.position.x;
    }
}
