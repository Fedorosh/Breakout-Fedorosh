using System.Collections;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "X_col" || other.tag == "Y_col")
        {
            obiekt.GetComponent<StartGame>().Lost = true;
    
        }
    }
}
