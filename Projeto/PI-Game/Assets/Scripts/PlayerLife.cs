﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerLife : MonoBehaviour
{
    Animator anim;
    public int vidas = 0;
    bool vivo = true;
    public GameObject lastCheckpoint;
    
    //public Vector3 respawnPoint;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        GameManager.gm.AtualizaHud();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RemoverEscudo() {
        StartCoroutine(ReEscudo());

    }
    IEnumerator ReEscudo() {
        yield return new WaitForSeconds(5);
        GameManager.shield = false;
    }
    public void PerdeVida() {
        if (vivo) {
            if (!GameManager.shield) {
                vivo = false;
                anim.SetTrigger("Morreu");
                GameManager.gm.SetVidas(-1);
                gameObject.GetComponent<PlayerAttack>().enabled = false;
                gameObject.GetComponent<PlayerController>().enabled = false;
            } else {
                RemoverEscudo();
                Debug.Log("OK");
            }
        }    
    }

    public void Reset() {
        if(GameManager.gm.GetVidas() >= 0) {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        

        if (outro.gameObject.CompareTag("vida"))
        {
            GameManager.vida = true;
            GameManager.gm.SetVidas(1);
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("shield"))
        {
            GameManager.escudo = true;
            GameManager.shield = true;
            gameObject.GetComponent<PlayerAttack>().enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = true;
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("win")) {
            GameManager.win = true;    
        }
    }
}
