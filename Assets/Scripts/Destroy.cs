using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destroy : MonoBehaviour
{
    private enum Colors : int { blue, white, red, yellow, orange }
    public GameObject prefab;
    private System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("GameController").GetComponent<StartGame>().Count_win = 0;

        collision.otherCollider.gameObject.active = false;


        foreach (var x in GameObject.FindGameObjectsWithTag("Block"))
        {
            GameObject.Find("GameController").GetComponent<StartGame>().Count_win++;

        }
        rand = new System.Random();
        int r = 2;//rand.Next(5);
        if (r == 2)
        {
            rand = new System.Random();
            r = rand.Next(0,5);
            prefab.GetComponent<fallBonus>().Color = r;
            Debug.Log(r);
            switch (r)
            {
                case (int)Colors.blue:
                    prefab.GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case (int)Colors.orange:
                    break;
                case (int)Colors.red:
                    break;
                case (int)Colors.white:
                    break;
                case (int)Colors.yellow:
                    break;


            }
            Instantiate(prefab, collision.otherCollider.transform.position, Quaternion.identity);

        }

    }
    // Update is called once per fra
    void Update()
    {
        
    }
}
