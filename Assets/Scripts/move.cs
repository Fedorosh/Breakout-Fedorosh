using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D bumper;
    public float speed;
    private float actual_x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        bumper = GetComponent<Rigidbody2D>();
        actual_x = bumper.transform.position.x;
        y = bumper.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right") && !Input.GetKey("left"))
        {
            //bumper.AddForce(new Vector2(-speed, 0.0f));
            bumper.transform.position = new Vector2(actual_x + speed, y);
        }
        if (Input.GetKey("left") && !Input.GetKey("right"))
        {
            //bumper.AddForce(new Vector2(speed, 0.0f));
            bumper.transform.position = new Vector2(actual_x - speed, y);
        }
        //else bumper.velocity = Vector2.zero;

        actual_x = bumper.transform.position.x;

    }
}
