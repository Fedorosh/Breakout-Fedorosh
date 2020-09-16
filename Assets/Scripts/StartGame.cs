using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Text play;
    private static StartGame instance;
    private bool lost;
    GameObject obiekt_ball,obiekt_pause,obiekt_win_lose;
    GameObject obiekt_back;
    int count_win;

    public GameObject bumperUp;
    public GameObject hoveUp;
    public GameObject steerUp;

    [SerializeField] Button one_player;
    [SerializeField] Button two_players;
    [SerializeField] TypeOfGame typeOfGame;

    public Canvas canvas;

    public bool Lost { get => lost; set => lost = value; }
    public int Count_win { get => count_win; set => count_win = value; }

    // Start is called before the first frame update
    void Start()
    {
        typeOfGame = GameObject.Find("TypeOfGame").GetComponent<TypeOfGame>();
        if (instance != null && instance != this)
            Destroy(this);
        else instance = this;
        Cursor.visible = false;
        count_win = 1;
        lost = false;

        //Check if the game should start
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            obiekt_ball = GameObject.Find("ball");
            obiekt_pause = GameObject.Find("pause");
            obiekt_win_lose = GameObject.Find("win/lose");
            obiekt_win_lose.active = false;
            obiekt_pause.active = false;
            GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
            //Check if it's only one player
            if (!typeOfGame.isTwoPlayers)
            {
                bumperUp.SetActive(false);
                hoveUp.SetActive(true);
                steerUp.SetActive(false);
            }
        }
        //Check if the scene is menu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            obiekt_back = GameObject.FindGameObjectWithTag("Finish");
            obiekt_back.active = false;
            obiekt_pause = GameObject.FindGameObjectWithTag("Interface");
        }

        




    }

    public void Resume()
    {
        play.gameObject.SetActive(false);

        obiekt_pause.active = false;
        EnableGame();
    }

    public void Back()
    {
        play.gameObject.SetActive(false); 
        //GameObject.FindGameObjectWithTag("Finish").active = false;
        obiekt_back.active = false;
        obiekt_pause.active = true;
        one_player.gameObject.active = false;
        two_players.gameObject.active = false;
    }

    public void SelectType()
    {
        one_player.gameObject.active = true;
        two_players.gameObject.active = true;
        obiekt_back.active = true;
        obiekt_pause.active = false;
    }

    public void Instruction()
    {
        play.gameObject.SetActive(true);
        obiekt_pause.active = false;
        //GameObject.FindGameObjectWithTag("Finish").active = true;
        obiekt_back.active = true;
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
        foreach (var x in GameObject.FindGameObjectsWithTag("bonus"))
        {
            x.gameObject.GetComponent<fallBonus>().enabled = true;
            x.gameObject.GetComponent<MeasureTime>().enabled = true;
        }
    }

    private void DisableGame()
    {
        foreach (var x in GameObject.Find("Bumpers").GetComponentsInChildren<MoveBumpers>())
            x.enabled = false;
        GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
        foreach (var x in GameObject.FindGameObjectsWithTag("bonus"))
        {
            x.gameObject.GetComponent<fallBonus>().enabled = false;
            x.gameObject.GetComponent<MeasureTime>().enabled = false;
        }
        
      
    }

    public void Pause()
    {
        play.gameObject.SetActive(true);
        play.text = "Pause";

                obiekt_pause.active = true;
                DisableGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            // if (Input.GetKey(KeyCode.Escape))
            // {
            //     play.text = "Pause";

            //     obiekt_pause.active = true;
            //     DisableGame();
            // }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) && !obiekt_win_lose.active && !obiekt_pause.active)
            {
                play.gameObject.SetActive(false);
                obiekt_ball.GetComponent<MoveBall>().enabled = true;
            }
            if (lost)
            {
                play.gameObject.SetActive(true);
                play.text = "You Lose!";

                obiekt_win_lose.active = true;
                DisableGame();
            }
            if (Count_win == 0)
            {
                play.gameObject.SetActive(true);
                play.text = "You win!";

                obiekt_win_lose.active = true;
                DisableGame();
            }
        }
        
        //if(SceneManager.GetActiveScene().buildIndex == 0)
        //{

        //}

        if (GameObject.FindObjectOfType<Button>() == null)
            Cursor.visible = false;
        else Cursor.visible = true;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

}
