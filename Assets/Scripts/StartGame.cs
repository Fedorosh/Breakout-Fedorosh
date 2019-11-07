using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text play;
    GameObject obiekt;
    // Start is called before the first frame update
    void Start()
    {
        obiekt = GameObject.Find("ball");
    }

    public void StartOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            play.text = "";
            obiekt.GetComponent<MoveBall>().enabled = true;
        }
    }
}
