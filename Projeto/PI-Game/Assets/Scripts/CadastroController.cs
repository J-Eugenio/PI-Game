using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CadastroController : MonoBehaviour {
    [SerializeField]
    private InputField nomeField = null;
    [SerializeField]
    private InputField sobrenomeField = null;
    [SerializeField]
    private InputField idadeField = null;
    [SerializeField]
    private InputField usuarioField = null;
    [SerializeField]
    private InputField senhaField = null;
    [SerializeField]
    private Text FeedBackMsgCad = null;


    private string urlCadastro = "http://game-pi.000webhostapp.com/pi/pi/controle/cadastro.php";


    void Start() {

    }

    public void Exit() {
        Application.Quit();
    }

    public void FazerCadastro() {
        if (nomeField.text == "" || sobrenomeField.text == "" || idadeField.text == "" || usuarioField.text == "" || senhaField.text == "") {
            FeedBakcError("Preencha todos os campos!");
        } else {
            StartCoroutine(ValidaCadastro());
        }
    }

    IEnumerator ValidaCadastro() {
        string nome = nomeField.text;
        string sobrenome = sobrenomeField.text;
        string idade = idadeField.text;
        string usuario = usuarioField.text;
        string senha = senhaField.text;
        string token = "YdTiqQBetWWdZXVzOP5M";
        using (UnityWebRequest www = UnityWebRequest.Get(urlCadastro + "?nome=" + nome + "&sobrenome=" + sobrenome + "&idade=" + idade + "&login=" + usuario + "&senha=" + senha + "&token=" + token)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            } else {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                if(www.downloadHandler.text == "1"){
                    FeedBackOK("Cadastro realizado com sucesso...");
                    StartCoroutine(CarregaScene());
                } else {
                    Debug.Log("Erro no cadastro");
                }
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator CarregaScene() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Login");
    }

    public void Voltar() {
        SceneManager.LoadScene("Login");
    }
    void FeedBackOK(string mensagem) {
        FeedBackMsgCad.CrossFadeAlpha(100f, 0, false);
        FeedBackMsgCad.color = Color.green;
        FeedBackMsgCad.text = mensagem;
    }

    void FeedBakcError(string mensagem) {
        FeedBackMsgCad.CrossFadeAlpha(100f, 0f, false);
        FeedBackMsgCad.color = Color.red;
        FeedBackMsgCad.text = mensagem;
        FeedBackMsgCad.CrossFadeAlpha(0f, 2f, false);
        nomeField.text = "";
        sobrenomeField.text = "";
        idadeField.text = "";
        usuarioField.text = "";
        senhaField.text = "";
    }
}
