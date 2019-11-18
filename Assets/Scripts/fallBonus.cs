using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class fallBonus : MonoBehaviour
{
    private CircleCollider2D bonus;
    private int color;

    private enum Colors : int { blue, white, red, yellow, orange }

    public int Color { get => color; set => color = value; }

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
        if(collision.collider.gameObject.tag == "bumper")
        {
            EnableEffect();
            this.GetComponent<MeasureTime>().TimerOn = true;
            GetComponent<SpriteRenderer>().color = UnityEngine.Color.clear;

        }
    }
    public void EnableEffect()
    {
        switch (color)
        {
            case (int)Colors.blue:
                foreach (var x in GameObject.FindGameObjectsWithTag("bumper"))
                    x.transform.localScale += new Vector3(10, 0, 0);
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
    }
    // Update is called once per frame
    void Update()
    {
        MoveBonus();
    }
}
