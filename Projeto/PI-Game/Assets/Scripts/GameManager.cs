﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool check = false;
    private int vidas = 2;
    public bool shield = false;
    public bool vida = false;
    public bool escudo = false;
    public bool velocidade = false;
    public bool win = false;
    public int ScoreTotal = 0;
    public int nInimigos = 0;
    public static string timer;
    public static bool isTimer = true;

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
    public void AddinimigosMortos(int inimigo) {
        this.nInimigos += inimigo;
    }
    public void AddScore(int inimigosMortos, int ScoreInimigo) {
        this.ScoreTotal += (inimigosMortos * ScoreInimigo);
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

    public void AttHudScore() {
        GameObject.Find("txtVidasScore").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("txtInimigosM").GetComponent<Text>().text = nInimigos.ToString();
        GameObject.Find("txtScore").GetComponent<Text>().text = ScoreTotal.ToString();
        GameObject.Find("txtTempo").GetComponent<Text>().text = timer;
    }

    public void SetVida(bool vida) {
        this.vida = vida;
    }
    public void SetEscudo(bool escudo) {
        this.escudo = escudo;
    }
    public void SetVelocidade(bool velocidade) {
        this.velocidade = velocidade;
    }
    public void SetWin(bool win) {
        this.win = win;
    }

    public bool GetVida() {
        return this.vida;
    }
    public bool GetEscudo() {
        return this.escudo;
    }
    public bool GetVelocidade() {
        return this.velocidade;
    }
    public bool GetWin() {
        return this.win;
    }

    public void SetShield(bool sh) {
        this.shield = sh;
    }
    public bool GetShield() {
        return this.shield;
    }
}
