﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBonus : MonoBehaviour
{
    private CircleCollider2D bonus;
    // Start is called before the first frame update
    void Start()
    {
        bonus = GetComponent<CircleCollider2D>();
        
    }

    private void MoveBonus()
    {
        bonus.transform.Translate(0, -0.05f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bumper")

            bonus.gameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBonus();
    }
}