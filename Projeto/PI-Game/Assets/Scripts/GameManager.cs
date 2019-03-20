using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private int vidas = 2;

    void Awake()
    {
        if(gm == null) {
            gm = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    void Start() {
        AtualizaHud();
    }
    void Update()
    {
        
    }

    public void SetVidas(int vida) {
        vidas += vida;
        if(vidas >= 0)
        AtualizaHud();
    }
    public int GetVidas() {
        return vidas;
    }

    public void AtualizaHud() {
        GameObject.Find("txtVidas").GetComponent<Text>().text = vidas.ToString();
    }

}
