using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlossarioController : MonoBehaviour
{
    public void IrSobreJogo() {
        StartCoroutine(SobreJogo());
    }
    IEnumerator SobreJogo() {
        yield return new WaitForSeconds(0);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GlossarioJogo");
    }
    public void IrSobrePersonagens() {
        StartCoroutine(SobrePersonagens());
    }
    IEnumerator SobrePersonagens() {
        yield return new WaitForSeconds(0);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GlossarioPersonagens");
    }
    public void IrSobreItens() {
        StartCoroutine(SobreItens());
    }
    IEnumerator SobreItens() {
        yield return new WaitForSeconds(0);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GlossarioItens");
    }
    public void Voltar() {
        StartCoroutine(carregarVoltar());
    }
    IEnumerator carregarVoltar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void VoltarGlossario() {
        StartCoroutine(carregarGlossario());
    }
    IEnumerator carregarGlossario() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("TelaGlossario");
    }
    public void Level1() {
        StartCoroutine(carregarLevel1());
    }
    IEnumerator carregarLevel1() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("Fase1");
    }
}
