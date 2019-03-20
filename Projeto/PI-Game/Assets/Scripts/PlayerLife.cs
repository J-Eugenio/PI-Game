using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    Animator anim;
    bool vivo = true;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        GameManager.gm.AtualizaHud();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
