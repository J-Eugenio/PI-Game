﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginController : MonoBehaviour {


    [SerializeField]
    private InputField usuarioF = null;
    [SerializeField]
    private InputField senhaF = null;
    [SerializeField]
    private Text FeedBackMsg = null;
    [SerializeField]
    private Toggle LembrarDados = null;

    private string url = "http://localhost/pi/controle/login.php";


    void Start () {
		if(PlayerPrefs.HasKey("lembra") && PlayerPrefs.GetInt("lembra") == 1) {
            usuarioF.text = PlayerPrefs.GetString("rememberLogin");
            senhaF.text = PlayerPrefs.GetString("rememberPass");
        }
	}

    public void Exit() {
        Application.Quit();
    }

	public void FazerLogin () {
        if (usuarioF.text == "" || senhaF.text == "") {
            FeedBakcError("Preencha todos os campos!");
        } else {
            string usuario = usuarioF.text;
            string senha = senhaF.text;

            if (LembrarDados.isOn) {
                PlayerPrefs.SetInt("lembra", 1);
                PlayerPrefs.SetString("rememberLogin", usuario);
                PlayerPrefs.SetString("rememberPass", senha);
            }

            WWW www = new WWW ( url + "?login=" + usuario + "&senha=" + senha );
            StartCoroutine(ValidaLogin(www));
        }
    }

    IEnumerator ValidaLogin(WWW www) {
        yield return www;
        if(www.error == null) {
            if (www.text == "1") {
                FeedBackOK("Login Realizado com sucesso\nCarregando Jogo...");
                StartCoroutine(CarregaScene());
            } else {
                FeedBakcError("Usuário ou Senha inválidos");
            }
        } else {
            if (www.error == "Cannot connect to destination") {
                FeedBakcError("Servidor Indisponivel!!");
            }
        }
    }

    IEnumerator CarregaScene() {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Cadastro");
    }

    void FeedBackOK(string mensagem) {
        FeedBackMsg.CrossFadeAlpha(100f, 0, false);
        FeedBackMsg.color = Color.green;
        FeedBackMsg.text = mensagem;
    }

    void FeedBakcError(string mensagem) {
        FeedBackMsg.CrossFadeAlpha(100f, 0f, false);
        FeedBackMsg.color = Color.red;
        FeedBackMsg.text = mensagem;
        FeedBackMsg.CrossFadeAlpha(0f, 2f, false);
        usuarioF.text = "";
        senhaF.text = "";
    }
}
