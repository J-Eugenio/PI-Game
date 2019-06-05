using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EstrelasController : MonoBehaviour
{
    public GameObject[] fase1 = new GameObject[3];//guarda as estrelas do score
    public GameObject[] fase2 = new GameObject[3];
    public Button fase_1, fase_2;
    public Sprite _lock;
    public GameObject texto1, texto2;
    void Start()
    {       

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerData.Unlocklevel1 == 0) {
            texto1.SetActive(false);
            fase_1.image.overrideSprite = _lock;
            fase_1.interactable = false;
        }
        if (PlayerData.Unlocklevel2 == 0) {
            texto2.SetActive(false);
            fase_2.image.overrideSprite = _lock;
            fase_2.interactable = false;
        }
        //estrelasFase1();
        //estrelasFase2();
    }
    void estrelasFase1() {
        if (GameManager.gm.fase1 >= 2500) {
            fase1[0].SetActive(true);
            fase1[1].SetActive(true);
            fase1[2].SetActive(true);

        } else if (GameManager.gm.fase1 >= 1800 && GameManager.gm.fase1 < 2500) {
            fase1[0].SetActive(true);
            fase1[1].SetActive(true);
            fase1[2].SetActive(false);
        } else if (GameManager.gm.fase1 >= 1000 && GameManager.gm.fase1 < 1800) {
            fase1[0].SetActive(true);
            fase1[1].SetActive(false);
            fase1[2].SetActive(false);
        } else {
            fase1[0].SetActive(false);
            fase1[1].SetActive(false);
            fase1[2].SetActive(false);
        }
    }
    void estrelasFase2() {
        if (GameManager.gm.fase2 >= 2500) {
            fase2[0].SetActive(true);
            fase2[1].SetActive(true);
            fase2[2].SetActive(true);

        } else if (GameManager.gm.fase2 >= 1800 && GameManager.gm.fase2 < 2500) {
            fase2[0].SetActive(true);
            fase2[1].SetActive(true);
            fase2[2].SetActive(false);
        } else if (GameManager.gm.fase2 >= 1000 && GameManager.gm.fase2 < 1800) {
            fase2[0].SetActive(true);
            fase2[1].SetActive(false);
            fase2[2].SetActive(false);
        } else {
            fase2[0].SetActive(false);
            fase2[1].SetActive(false);
            fase2[2].SetActive(false);
        }
    }
}
