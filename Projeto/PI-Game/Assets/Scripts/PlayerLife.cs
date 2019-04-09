using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject lastCheckpoint;
    Animator anim;
    bool vivo = true;
    public Vector3 respawnPoint;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        GameManager.gm.AtualizaHud();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // //setando se ele tocar em alguma tag com o nome ele aparece no reapwan
    //void OnTriggerEnter2D(Collider2D other)
    // {
    //aqui é para quando ele morre, vir para o check point atual
    //if (other.tag == "")
    // {
    // transform.position = respawnPoint;
    // }
    //aqui é marcando, se ele chegou no checkpoint, ele salva.
    // if(other.tag == "Checkpoint")
    // {
    //  respawnPoint = other.transform.position;
    //}
    //}

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        lastCheckpoint = collider2D.gameObject;
    }


    public void PerdeVida() {
        if (vivo) {
            vivo = false;
            anim.SetTrigger("Morreu");
            GameManager.gm.SetVidas(-1);
            gameObject.GetComponent<PlayerAttack>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;

        }
        
    }

    public void Reset() {
        if(GameManager.gm.GetVidas() >= 0) {
            gameObject.GetComponent<PlayerAttack>().enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = true;
            transform.position = lastCheckpoint.transform.position;
        }
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
