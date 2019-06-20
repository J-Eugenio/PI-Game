using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
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

    private string urlLogin = "http://game-pi.000webhostapp.com/pi/pi/controle/login.php";

    void Start () {
		if(PlayerPrefs.HasKey("lembra") && PlayerPrefs.GetInt("lembra") == 1) {
            usuarioF.text = PlayerPrefs.GetString("rememberLogin");
            senhaF.text = PlayerPrefs.GetString("rememberPass");
        }
	}

    public void Exit() {
        Application.Quit();
    }
    public void  irCadastro() {
        SceneManager.LoadScene("Cadastro");
    }
    public void FazerLogin () {
        if (usuarioF.text == "" || senhaF.text == "") {
            FeedBakcError("Preencha todos os campos!");
        } else {
            StartCoroutine(ValidaLogin());
        }
    }

    IEnumerator ValidaLogin() {
        string usuario = usuarioF.text;
        string senha = senhaF.text;
        string token = "YdTiqQBetWWdZXVzOP5M";

        using (UnityWebRequest www = UnityWebRequest.Get(urlLogin + "?login=" + usuario + "&senha=" + senha + "&token=" + token)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            } else {
                // Show results as text
                if (www.downloadHandler.text == "0") {
                    FeedBackOK("Login/senha incorretos...");
                    Debug.Log("Erro no Login");
                } else {
                    FeedBackOK("Login realizado com sucesso...");
                    PlayerData.UsuarioId = www.downloadHandler.text;
                    PlayerPrefs.SetString("UsuarioId", PlayerData.UsuarioId);
                    Debug.Log("Id: "+PlayerData.UsuarioId);
                    StartCoroutine(CarregaScene());
                }
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator CarregaScene() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MenuPrincipal");
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
