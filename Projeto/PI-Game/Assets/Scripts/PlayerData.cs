using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string level;
    public static float posX, posY, posZ;
    public static int vidas;
    public GameObject[] datas;

    void Awake()
    {
        datas = GameObject.FindGameObjectsWithTag("DATA");
        if(datas.Length >= 2)
        {
            Destroy(datas[0]);
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start() {
        if(PlayerPrefs.HasKey("PosX") && PlayerPrefs.HasKey("PosY") &&
            PlayerPrefs.HasKey("PosZ") && PlayerPrefs.HasKey("Level") &&
            PlayerPrefs.HasKey("Vidas")) {
            posX = PlayerPrefs.GetFloat("PosX");
            posY = PlayerPrefs.GetFloat("PosY");
            posZ = PlayerPrefs.GetFloat("PosZ");
            level = PlayerPrefs.GetString("Level");
            vidas = PlayerPrefs.GetInt("Vidas");
        } else {
            PlayerPrefs.SetString("Level", level);
            PlayerPrefs.SetFloat("PosX", posX);
            PlayerPrefs.SetFloat("PosY", posY);
            PlayerPrefs.SetFloat("PosZ", posZ);
            PlayerPrefs.SetInt("Vidas", vidas);
        }
    }
}
