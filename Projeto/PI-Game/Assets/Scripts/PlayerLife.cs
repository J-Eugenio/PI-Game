using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class PlayerLife : MonoBehaviour
{
    Animator anim;
    public int vidas = 0;
    bool vivo = true;
    [SerializeField]
    private Button direita, esquerda, atack1, atack2, pulo;
    
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
        GameManager.gm.SetShield(false);
    }
    public void PerdeVida() {
        if (vivo) {
            if (!GameManager.gm.GetShield()) {
                gameObject.GetComponent<PlayerAttack>().enabled = false;
                gameObject.GetComponent<PlayerController>().enabled = false;
                direita.interactable = false;
                esquerda.interactable = false;
                pulo.interactable = false;
                atack1.interactable = false;
                atack2.interactable = false;
                vivo = false;
                anim.SetTrigger("Morreu");
                GameManager.gm.SetVidas(-1);
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
            GameManager.gm.SetVida(true);
            GameManager.gm.SetVidas(1);
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("shield"))
        {
            GameManager.gm.SetShield(true);
            GameManager.gm.SetEscudo(true);
            RemoverEscudo();
            gameObject.GetComponent<PlayerAttack>().enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = true;
            Destroy(outro.gameObject);
        }
        if (outro.gameObject.CompareTag("win")) {
            GameManager.gm.SetWin(true);
        }
    }
}
