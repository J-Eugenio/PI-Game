using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool check = false;
    private int vidas = 2;
    public static bool shield = false;
    public static bool vida, escudo, velocidade, win = false;
    public static int NumeroInimigosMortos = 0;
    public static int ScoreInimigosMortos = 0;

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
    
    public void Addvidas(int vidas) {
        this.vidas = vidas;
    }
    public void SetVidas(int vida) {
        vidas += vida;
        if(vidas >= 0)
        {
            AtualizaHud();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
            vidas = 2;
            //carregando duas vidas novas para quando acessar a tela de game over e jogar novamente ele já ter 2 novas vidas,
            //e não continuar diminuindo.
        }
        
    }
    public int GetVidas() {
        return vidas;
    }

    public void AtualizaHud() {
        GameObject.Find("txtVidas").GetComponent<Text>().text = vidas.ToString();
    }

}
