using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureTime : MonoBehaviour
{
    bool timerOn;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        timerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            time += Time.deltaTime;
            int seconds = (int)(time % 60);
            if(seconds == 10)
            {
                timerOn = false;

            }
        }
    }
}
