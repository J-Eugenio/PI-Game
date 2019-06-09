using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerCount : MonoBehaviour
{

    public Text Timer;
    private float startTime;
    private float diferenca = 0;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.gm.ativarTime) {
            t = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.ativarTime) {
            t += (1.0f * Time.deltaTime);
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            Timer.text = minutes + ":" + seconds;
            GameManager.gm.tempo = Timer.text;
        }

    }
}