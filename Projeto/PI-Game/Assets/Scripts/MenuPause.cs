using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class MenuPause : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;


    private string urlLogin = "http://game-pi.000webhostapp.com/pi/pi/controle/score.php";
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
	}

    public void Resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        pauseMenuUi.SetActive(true);
        Time.timeScale =0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void pulerTutorial()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial") {
            PlayerData.Unlocklevel1 = 1;
            PlayerPrefs.SetInt("UnlockLevel1", PlayerData.Unlocklevel1);
            Debug.Log(PlayerData.Unlocklevel1);
            SceneManager.LoadScene("Fase1");
        }

    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ReiniciarPartida() {
        Time.timeScale = 1f;
        GameManager.gm.Addvidas(PlayerPrefs.GetInt("Vidas"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //salvar score no banco de dados
    IEnumerator salvarScoreNoBanco(string faseName) {
        string fase = faseName;//SceneManager.GetActiveScene().name;
        int qtdMonstro = GameManager.gm.nInimigos;
        int pontuacao = GameManager.gm.ScoreTotal;
        int pontuacaoPuzzle = GameManager.gm.scorePuzzle;
        int nTentativas = GameManager.gm.nTentativasScore;
        string idUsuario = PlayerData.UsuarioId;

        string token = "YdTiqQBetWWdZXVzOP5M";

        using (UnityWebRequest www = UnityWebRequest.Get(urlLogin + "?fase=" + fase + "&qtdMonstro=" + qtdMonstro + "&pontuacao=" + pontuacao + "&pontuacaoPuzzle=" + pontuacaoPuzzle + "&tentativasPuzzle="+ nTentativas + "&idUsuario=" + idUsuario + "&token=" + token)) {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            } else {
                // Show results as text
                if (www.downloadHandler.text == "0") {
                    Debug.Log("Erro ao salvar score");
                } else {
                    Debug.Log("Score salvo");
                }
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }
    public void telaLeveis() {
        if(SceneManager.GetActiveScene().name == "Tutorial") {
            PlayerData.Unlocklevel1 = 1;
            PlayerPrefs.SetInt("UnlockLevel1", PlayerData.Unlocklevel1);    
        }
        if (SceneManager.GetActiveScene().name == "Fase1") {
            PlayerData.Unlocklevel2 = 1;
            PlayerPrefs.SetInt("UnlockLevel2", PlayerData.Unlocklevel2);
            StartCoroutine(salvarScoreNoBanco(SceneManager.GetActiveScene().name));
        }
        if (SceneManager.GetActiveScene().name == "Fase2") {
            SceneManager.LoadScene("TelaLeveis");
            StartCoroutine(salvarScoreNoBanco(SceneManager.GetActiveScene().name));
        }
        SceneManager.LoadScene("TelaLeveis");
    }
}
