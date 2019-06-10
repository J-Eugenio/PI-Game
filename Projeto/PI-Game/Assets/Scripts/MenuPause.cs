using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
  
    

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

    public void telaLeveis() {
        if(SceneManager.GetActiveScene().name == "Tutorial") {
            PlayerData.Unlocklevel1 = 1;
            PlayerPrefs.SetInt("UnlockLevel1", PlayerData.Unlocklevel1);
        }
        if (SceneManager.GetActiveScene().name == "Fase1") {
            PlayerData.Unlocklevel2 = 1;
            PlayerPrefs.SetInt("UnlockLevel2", PlayerData.Unlocklevel2);
        }
        SceneManager.LoadScene("TelaLeveis");
    }
}
