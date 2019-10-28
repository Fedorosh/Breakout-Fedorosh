using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D bumper;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        bumper = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {
            bumper.AddForce(new Vector2(-speed, 0.0f));
        }
        else if (Input.GetKey("right"))
        {
            bumper.AddForce(new Vector2(speed, 0.0f));
        }
        else bumper.velocity = Vector2.zero;

        if (bumper.position.x >= 10.4f && bumper.position.x <= -10.4f)
        {
            if (bumper.position.x < 0)
                bumper.position = new Vector2(-10.4f, -5.5f);
            if (bumper.position.x > 0)
                bumper.position = new Vector2(10.4f, -5.5f);
        }
    }
}
