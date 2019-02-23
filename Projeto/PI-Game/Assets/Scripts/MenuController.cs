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
    IEnumerator carregarScena() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1");
    }
}
