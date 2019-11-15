using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text play;
    private bool lost;
    GameObject obiekt_ball,obiekt_pause,obiekt_win_lose;
    int count_win;

    public bool Lost { get => lost; set => lost = value; }
    public int Count_win { get => count_win; set => count_win = value; }


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        count_win = 1;
        lost = false;
        obiekt_ball = GameObject.Find("ball");
        obiekt_pause = GameObject.Find("pause");
        obiekt_win_lose = GameObject.Find("win/lose");
        obiekt_win_lose.active = false;
        obiekt_pause.active = false;
        GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
        
    }

    public void Resume()
    {
        play.text = "";

        obiekt_pause.active = false;
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

            obiekt_pause.active = true;
            DisableGame();
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) && !obiekt_win_lose.active && !obiekt_pause.active)
        {
            play.text = "";
            obiekt_ball.GetComponent<MoveBall>().enabled = true;
        }
        if (lost)
        {
            play.text = "You Lose!";
            
            obiekt_win_lose.active = true;
            DisableGame();
        }
        if (Count_win == 0)
        {
            play.text = "You win!";

            obiekt_win_lose.active = true;
            DisableGame();
        }
        if (GameObject.FindGameObjectWithTag("Interface") == null)
            Cursor.visible = false;
        else Cursor.visible = true;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
