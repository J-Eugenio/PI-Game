using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuOptions : MonoBehaviour {
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolucoes;
    public Slider volume;
    void Start() {
        audioMixer.SetFloat("volume", volume.value);
        resolutions = Screen.resolutions;
        resolucoes.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++) {
            if(resolutions[i].width < 800 && resolutions[i].height < 600) {
                continue;
            }
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if(!options.Contains(option))
            options.Add(option);
            
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolucoes.AddOptions(options);
        resolucoes.value = currentResolutionIndex;
        resolucoes.RefreshShownValue();
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
