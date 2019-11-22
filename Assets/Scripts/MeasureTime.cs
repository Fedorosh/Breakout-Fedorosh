using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureTime : MonoBehaviour
{
    bool timerOn;
    float time;

    public bool TimerOn { get => timerOn; set => timerOn = value; }
    public float Time { get => time; set => time = value; }

    private enum Colors : int { blue, white, red, yellow, orange }

    // Start is called before the first frame update
    void Start()
    {
        Time = 0.0f;
        TimerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            Time += UnityEngine.Time.deltaTime;
            int seconds = (int)(Time % 60);
            if(seconds == 10)
            {
                DisableEffect();
                TimerOn = false;
                gameObject.active = false;
            }
        }
    }

    void DisableEffect()
    {
        switch (GetComponent<fallBonus>().Color)
        {
            case (int)Colors.blue:
                foreach (var x in GameObject.FindGameObjectsWithTag("bumper"))
                    x.transform.localScale = x.transform.localScale - new Vector3(10, 0, 0);
                break;
            case (int)Colors.orange:
                GameObject.FindGameObjectWithTag("X_col").transform.localScale -= new Vector3(10, 10);
                break;
            case (int)Colors.red:
                GameObject.Find("bumperUp").GetComponent<MoveBall>().speed *= -1;
                break;
            case (int)Colors.white:
                break;
            case (int)Colors.yellow:
                break;


        }
    }
}
