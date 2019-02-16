using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginController : MonoBehaviour {

    private const string Login = "Admin";
    private const string Pass = "Admin";

    [SerializeField]
    private InputField usuarioF = null;
    [SerializeField]
    private InputField senhaF = null;
    [SerializeField]
    private Text FeedBackMsg = null;
    [SerializeField]
    private Toggle LembrarDados = null;

    
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
        string usuario = usuarioF.text;
        string senha = senhaF.text;

        if (LembrarDados.isOn) {
            PlayerPrefs.SetInt("lembra", 1);
            PlayerPrefs.SetString("rememberLogin", usuario);
            PlayerPrefs.SetString("rememberPass", senha);
        }

        if(usuario == Login && senha == Pass) {
            FeedBackMsg.CrossFadeAlpha(100f, 0, false);
            FeedBackMsg.color = Color.green;
            FeedBackMsg.text = "Login realizado com sucesso\nCarregando Jogo...";
            StartCoroutine(CarregaScene());
        } else {
            FeedBackMsg.CrossFadeAlpha(100f, 0f, false);
            FeedBackMsg.color = Color.red;
            FeedBackMsg.text = "Usuário ou Senha inválidos";
            FeedBackMsg.CrossFadeAlpha(0f, 2f, false);
            usuarioF.text = "";
            senhaF.text = "";
        }
    }

    IEnumerator CarregaScene() {
        yield return new WaitForSeconds(5);
        Application.LoadLevel("Level1Exemplo");
    }
}
