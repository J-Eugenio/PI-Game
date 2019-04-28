﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerCount : MonoBehaviour
{

    public Text Timer;
    
    private float startTime;

        
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isTimer) {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            Timer.text = minutes + ":" + seconds;
            GameManager.timer = Timer.text;
        }
        
    }
}