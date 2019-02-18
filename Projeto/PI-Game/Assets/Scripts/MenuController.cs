using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Exit()
    {
        Application.Quit();
    }
    public void carregarScena()
    {
        StartCoroutine(CarregaScene());
    }
    IEnumerator CarregaScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level1");
    }
}
