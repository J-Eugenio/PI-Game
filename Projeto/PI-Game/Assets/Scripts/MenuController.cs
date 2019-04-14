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
    public void CarregarJogo() {
        StartCoroutine(Carregar());
    }
    public void Options() {
        StartCoroutine(carregarOptions());
    }
    public void VoltarIni() {
        StartCoroutine(carregarVoltarIni());
    }
    public void Voltar() {
        StartCoroutine(carregarVoltar());
    }
    public void IrGlossario() {
        StartCoroutine(Glossario());
    }
    IEnumerator carregarScena() {
        yield return new WaitForSeconds(0);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
    }
    IEnumerator Carregar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("TelaSaves");
    }
    IEnumerator carregarOptions() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuOptions");
    }
    IEnumerator carregarVoltar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
    IEnumerator carregarVoltarIni() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
    IEnumerator Glossario() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("TelaGlossario");
    }
}
