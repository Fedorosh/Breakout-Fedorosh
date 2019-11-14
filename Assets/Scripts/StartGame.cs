using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text play;
    private bool lost;
    GameObject obiekt_ball,obiekt_interface;
    int count_win;

    public bool Lost { get => lost; set => lost = value; }
    public int Count_win { get => count_win; set => count_win = value; }


    // Start is called before the first frame update
    void Start()
    {
        count_win = 1;
        lost = false;
        obiekt_ball = GameObject.Find("ball");
        obiekt_interface = GameObject.Find("Interface");
        obiekt_interface.active = false;
        GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
        
    }

    public void Resume()
    {
        play.text = "";

        obiekt_interface.active = false;
        EnableGame();
    }

    public void StartOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void EnableGame()
    {
        foreach (var x in GameObject.Find("Bumpers").GetComponentsInChildren<MoveBumpers>())
            x.enabled = true;
        GameObject.Find("ball").GetComponent<MoveBall>().enabled = true;
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
        Debug.Log(count_win);
        if(Input.GetKey(KeyCode.Escape))
        {
            play.text = "Pause";

            obiekt_interface.active = true;
            DisableGame();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            play.text = "";
            obiekt_ball.GetComponent<MoveBall>().enabled = true;
        }
        if (lost)
        {
            play.text = "You Lose!";
            
            obiekt_interface.active = true;
            DisableGame();
        }
        if (Count_win == 0)
        {
            play.text = "You win!";

            obiekt_interface.active = true;
            DisableGame();
        }
    }
}
