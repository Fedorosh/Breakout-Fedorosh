using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D bumper;
    public float speed;
    private float actual_x;
    private float y;
    private enum sign : int { plus = 1 ,minus = -1 };
    // Start is called before the first frame update
    void Start()
    {
        bumper = GetComponent<Rigidbody2D>();
        ActualPosition();
        y = bumper.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey("right") && !Input.GetKey("left"))
            {
                //bumper.AddForce(new Vector2(-speed, 0.0f));
                MoveBumper((float)sign.plus);
            }
            if (Input.GetKey("left") && !Input.GetKey("right"))
            {
                //bumper.AddForce(new Vector2(speed, 0.0f));
                MoveBumper((float)sign.minus);
            }

        //else bumper.velocity = Vector2.zero;
        //Vector2 temp = transform.position;
        //temp.x += Input.GetKeyDown(KeyCode.RightArrow);
        //bumper.transform.position = new Vector2(actual_x + speed, y);

        ActualPosition();

    }

    private void MoveBumper(float sign)
    {
        bumper.transform.position = new Vector2(actual_x  + (speed * sign), y);
    }
    private void ActualPosition()
    {
        actual_x = bumper.transform.position.x;
    }
}
