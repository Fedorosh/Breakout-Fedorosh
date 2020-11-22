using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum TypeOfGame
{
    solo = 0,
    duo = 1
}

public class GameController : MonoBehaviour
{
    public Text play;
    private static GameController instance;
    private bool lost;
    GameObject obiekt_ball,obiekt_pause,obiekt_win_lose;
    GameObject obiekt_back;
    int count_win;
    private TypeOfGame typeOfGame;


    public static GameController Instance { get { return instance; } }

    private bool[,] blockPatterns;

    const int TOTAL_BLOCKS_X = 6;
    const int TOTAL_BLOCKS_Y = 10;

    public GameObject bumperUp;
    public GameObject hoveUp;
    public GameObject steerUp;
    public Canvas canvas;

    public bool Lost { get => lost; set => lost = value; }
    public int Count_win { get => count_win; set => count_win = value; }

    // Start is called before the first frame update
    void Start()
    {

        if (instance != null && instance != this)
            Destroy(this);
        else instance = this;

        DontDestroyOnLoad(instance.gameObject);
#if UNITY_EDITOR
        Cursor.visible = false;
#endif
        count_win = 1;
        lost = false;

        //Check if the game should start
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    obiekt_ball = GameObject.Find("ball");
        //    obiekt_pause = GameObject.Find("pause");
        //    obiekt_win_lose = GameObject.Find("win/lose");
        //    obiekt_win_lose.SetActive(false);
        //    obiekt_pause.SetActive(false);
        //    GameObject.Find("ball").GetComponent<MoveBall>().enabled = false;
        //    //Check if it's only one player
        //    if (!typeOfGame.isTwoPlayers)
        //    {
        //        bumperUp.SetActive(false);
        //        hoveUp.SetActive(true);
        //        steerUp.SetActive(false);
        //    }
        //}

    }

    public void StartOnePlayer()
    {
        typeOfGame = TypeOfGame.solo;
        SceneManager.LoadScene(1);
    }

    public void StartTwoPlayers()
    {
        typeOfGame = TypeOfGame.duo;
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        play.gameObject.SetActive(false);

        obiekt_pause.SetActive(false); 
        EnableGame();
    }

    private void RandomizeBlocks()
    {
        System.Random rand = new System.Random();
    }
    

    private void GenerateBlocks()
    {
        blockPatterns = new bool[TOTAL_BLOCKS_X, TOTAL_BLOCKS_Y];
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < blockPatterns.GetLength(1); i++)
        {
            for (int j = 0; j < blockPatterns.GetLength(0); j++)
                if (j % 2 == 0)

                    blockPatterns[j, i] = true;
                else
                    blockPatterns[j, i] = false;
        }
        int blocksIndex = 0;
        //foreach (var x in blockPatterns)
        //{
        //    if (!x) Destroy(blocks[blocksIndex]);
        //    blocksIndex++;
        //}
        for (int i = 0; i < blockPatterns.GetLength(0); i++)
        {
            for (int j = 0; j < blockPatterns.GetLength(1); j++)
            {
                if (!blockPatterns[i, j])
                    Destroy(blocks[blocksIndex]);
                blocksIndex++;
            }
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
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
        foreach (var x in GameObject.FindGameObjectsWithTag("steer"))
            x.GetComponent<MoveMover>().enabled = true;
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

        foreach (var x in GameObject.FindGameObjectsWithTag("steer"))
            x.GetComponent<MoveMover>().enabled = false;
        
      
    }

    public void Pause()
    {
        play.gameObject.SetActive(true);
        play.text = "Pause";

                obiekt_pause.SetActive(true);
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
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) && !obiekt_win_lose.activeSelf && !obiekt_pause.activeSelf)
            {
                play.gameObject.SetActive(false);
                obiekt_ball.GetComponent<MoveBall>().enabled = true;
            }
            if (lost)
            {
                play.gameObject.SetActive(true);
                play.text = "You lose!";

                obiekt_win_lose.SetActive(true);
                DisableGame();
            }
            if (Count_win == 0)
            {
                play.gameObject.SetActive(true);
                play.text = "You win!";

                obiekt_win_lose.SetActive(true);
                DisableGame();
            }
        }

        //if(BlockBorders != null)
        //{
        //    Debug.LogError(BlockBorders.rect.width);
        //    Debug.LogError(BlockBorders.rect.height);
        //    Debug.LogError(BlockBorders.anchoredPosition.x);
        //    Debug.LogError(BlockBorders.anchoredPosition.y);
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
