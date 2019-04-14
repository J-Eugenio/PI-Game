﻿using System.Collections;
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
        SceneManager.LoadScene("Fase1");
        
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ReiniciarPartida() {
        Time.timeScale = 1f;
        GameManager.gm.Addvidas(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
