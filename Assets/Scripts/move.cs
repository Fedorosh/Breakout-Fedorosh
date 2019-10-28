using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody2D bumper;
    // Start is called before the first frame update
    void Start()
    {
        bumper = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            bumper.AddForce(new Vector2(-10.0f, 0.0f));
            
        }
        else if (Input.GetKey("right"))
        {
            bumper.AddForce(new Vector2(10.0f, 0.0f));
        }
        else bumper.velocity = Vector2.zero;
    }
}
