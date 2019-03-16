using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {

    // Use this for initialization
    public void Exit() {
        Application.Quit();
    }
    public void Jogar() {
        StartCoroutine(carregarScena());
    }
    public void Options() {
        StartCoroutine(carregarOptions());
    }
    public void Voltar() {
        StartCoroutine(carregarVoltar());
    }
    IEnumerator carregarScena() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1");
    }
    IEnumerator carregarOptions() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuOptions");
    }
    IEnumerator carregarVoltar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
