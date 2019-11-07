using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text play;
    private bool lost, won;
    GameObject obiekt_ball,obiekt_interface;

    public bool Lost { get => lost; set => lost = value; }
    public bool Won { get => won; set => won = value; }

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        won = false;
        obiekt_ball = GameObject.Find("ball");
        obiekt_interface = GameObject.Find("Interface");
        obiekt_interface.active = false;
        GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
    }

    public void StartOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void DisableGame()
    {
        foreach (var x in GameObject.Find("Bumpers").GetComponentsInChildren<MoveBumpers>())
            x.enabled = false;
        GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
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
            obiekt_ball.GetComponent<MoveBall>().enabled = true;
        }
        if (lost)
        {
            play.text = "You Lost!";
            
            obiekt_interface.active = true;
            DisableGame();
        }
    }
}
