using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public Text cronometro;
    [SerializeField]
    private float contagem = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(contagem > 0) {
            contagem -= Time.deltaTime;
            cronometro.text = contagem.ToString("0");
        } else {
            cronometro.text = "";
        }
    }
}
