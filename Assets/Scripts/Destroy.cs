using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
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

    }
    // Update is called once per fra
    void Update()
    {
        
    }
}
