using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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


    private string urlCadastro = "http://localhost/pi/controle/cadastro.php";


    void Start() {

    }

    public void Exit() {
        Application.Quit();
    }

    public void FazerCadastro() {
        if (nomeField.text == "" || sobrenomeField.text == "" || idadeField.text == "" || usuarioField.text == "" || senhaField.text == "") {
            FeedBakcError("Preencha todos os campos!");
        } else {
            string nome = nomeField.text;
            string sobrenome = sobrenomeField.text;
            string idade = idadeField.text;
            string usuario = usuarioField.text;
            string senha = senhaField.text;

            WWW www = new WWW(urlCadastro + "?nome=" + nome + "&sobrenome=" + sobrenome + "&idade=" + idade + "&login=" + usuario + "&senha=" + senha);
            StartCoroutine(ValidaCadastro(www));
        }
    }

    IEnumerator ValidaCadastro(WWW www) {
        yield return www;
        if (www.error == null) {
            if (www.text == "1") {
                FeedBackOK("Cadastro Realizado com sucesso...");
                StartCoroutine(CarregaScene());
            }
        } else {
            if (www.error == "Cannot connect to destination") {
                FeedBakcError("Servidor Indisponivel!!");
            }
        }
    }

    IEnumerator CarregaScene() {
        yield return new WaitForSeconds(2);
        Application.LoadLevel("Login");
    }

    public void Voltar() {
        Application.LoadLevel("Login");
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
