using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SavesController : MonoBehaviour
{
    public void Exit() {
        Application.Quit();
    }
    public void JogarLv1() {
        StartCoroutine(carregarScenaLv1());
    }
    public void Jogar_leveis() {
        StartCoroutine(carregarLeveis());
    }
    public void Voltar() {
        StartCoroutine(carregarVoltar());
    }
    IEnumerator carregarScenaLv1() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Fase1");
    }
    IEnumerator carregarLeveis() {
        yield return new WaitForSeconds(0);
        //if (PlayerPrefs.GetString("Level").Equals("")) {
        //    SceneManager.LoadScene("Tutorial");
        //} else {
        //    SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
        //}
        SceneManager.LoadScene("TelaLeveis");
    }
    IEnumerator carregarVoltar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
