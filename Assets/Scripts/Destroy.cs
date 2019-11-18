using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destroy : MonoBehaviour
{
    public GameObject prefab;
    private System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("GameController").GetComponent<StartGame>().Count_win = 0;

        collision.other.gameObject.active = false;


        foreach (var x in GameObject.FindGameObjectsWithTag("Block"))
        {
            GameObject.Find("GameController").GetComponent<StartGame>().Count_win++;

        }
        //rand = new System.Random();
        //int r = rand.Next(5);
        //Debug.Log(r);
        //if(r == 2)
        Instantiate(prefab, collision.other.transform.position, Quaternion.identity);

    }
    // Update is called once per fra
    void Update()
    {
        
    }
}
