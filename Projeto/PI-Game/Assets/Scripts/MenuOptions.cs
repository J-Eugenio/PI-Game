using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuOptions : MonoBehaviour {
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolucoes;
    public Slider volume;
    void Start() {
        audioMixer.SetFloat("volume", volume.value);
        resolucoes.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions) {
            //800 x 600 @ 60Hz
            resolucoes.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }


    public void OnResolutionChange() {
        Screen.SetResolution(resolutions[resolucoes.value].width, resolutions[resolucoes.value].height, Screen.fullScreen);
    }
	public void SetVolume() {
        audioMixer.SetFloat("volume", volume.value);
    }

    public void SetQuality(int index) {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen( bool isFull) {
        Screen.fullScreen = isFull;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
    
    public void Voltar() {
        StartCoroutine(carregarVoltar());
    }
    IEnumerator carregarVoltar() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
