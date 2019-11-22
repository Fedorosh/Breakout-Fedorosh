using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destroy : MonoBehaviour
{
    private enum Colors : int { blue, white, red, yellow, orange }
    public GameObject prefab;
    private System.Random rand;

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
            GameObject pre = Instantiate(prefab, collision.otherCollider.transform.position, Quaternion.identity);
            rand = new System.Random();
            r = rand.Next(0,5);
            pre.GetComponent<fallBonus>().Color = r;
            switch (r)
            {
                case (int)Colors.blue:
                    pre.GetComponent<SpriteRenderer>().color = Color.blue;
                    if (pre.GetComponent<MeasureTime>().TimerOn)
                        pre.GetComponent<MeasureTime>().Time = 0.0f;
                    break;
                case (int)Colors.orange:
                    pre.GetComponent<SpriteRenderer>().color = Color.green;
                    if (pre.GetComponent<MeasureTime>().TimerOn)
                        pre.GetComponent<MeasureTime>().Time = 0.0f;
                    break;
                case (int)Colors.red:
                    pre.GetComponent<SpriteRenderer>().color = Color.red;
                    if (pre.GetComponent<MeasureTime>().TimerOn)
                        pre.GetComponent<MeasureTime>().Time = 0.0f;
                    break;
                case (int)Colors.white:
                    pre.GetComponent<SpriteRenderer>().color = Color.white;
                    if (pre.GetComponent<MeasureTime>().TimerOn)
                        pre.GetComponent<MeasureTime>().Time = 0.0f;
                    break;
                case (int)Colors.yellow:
                    pre.GetComponent<SpriteRenderer>().color = Color.yellow;
                    if (pre.GetComponent<MeasureTime>().TimerOn)
                        pre.GetComponent<MeasureTime>().Time = 0.0f;
                    break;


            }

        }

    }
}
