﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failure : MonoBehaviour
{
    GameObject obiekt;
    private void Start()
    {
        obiekt = GameObject.Find("GameController");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "X_col" || other.tag == "Y_col")
        {
            obiekt.GetComponent<GameController>().Lost = true;
    
        }
    }
}
