using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    protected Rigidbody2D bumper;
    //protected MeshCollider bumper1;
    public float speed;
    protected float x;
    protected float y;
    protected bool isCollidedLeft,isCollidedRight;
    protected enum sign : int { plus = 1, minus = -1 };
    public Camera kamera;
    private float translation;

    public float Translation { get => translation; set => translation = value; }

    protected virtual void Start()
    {
        isCollidedLeft = false;
        isCollidedRight = false;
        bumper = GetComponent<Rigidbody2D>();
        ActualPosition();
        y = bumper.transform.position.y;
    }

    virtual protected void MoveBumper(float sign = 1.0f)
    {
        bumper.transform.position = new Vector2(x + (speed * sign), y);
    }
    virtual protected void ActualPosition()
    {
        x = bumper.transform.position.x;
    }
}
