using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : Move
{
    // Start is called before the first frame update
    protected override void Start()
    {
        bumper = GetComponent<Rigidbody2D>();
        ActualPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void ActualPosition()
    {
        x = bumper.transform.position.x;
        y = bumper.transform.position.y;
    }
}
