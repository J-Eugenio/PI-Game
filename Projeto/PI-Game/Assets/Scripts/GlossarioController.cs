using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlossarioController : MonoBehaviour
{
    public void Exit() {
        Application.Quit();
    }
    public void JogarLv1() {
        StartCoroutine(carregarScenaLv1());
    }
    public void Voltar() {
        StartCoroutine(carregarVoltar());
    }
    IEnumerator carregarScenaLv1() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Fase1");
    }
    IEnumerator carregarVoltar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
