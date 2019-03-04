using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    Animator anim;
    public float intervaloDeAtaque;
    public float intervaloDeAtaque2;
    private float proximoAtaque;

	void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && Time.time > proximoAtaque) {
            Atacando();
        }else if (Input.GetButtonDown("Fire2") && Time.time > proximoAtaque) {
            Atacando2();
        }
    }

    void Atacando() {
        anim.SetTrigger("Ataque");
        proximoAtaque = Time.time + intervaloDeAtaque;
    }

    void Atacando2() {
        anim.SetTrigger("Ataque2");
        proximoAtaque = Time.time + intervaloDeAtaque2;
    }
}
