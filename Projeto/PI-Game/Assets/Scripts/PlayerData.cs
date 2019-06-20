using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int Unlocklevel1 = 0;
    public static int Unlocklevel2 = 0;
    public static string level;
    public static float posX, posY, posZ;
    public static int vidas;
    public static string UsuarioId;
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
            PlayerPrefs.HasKey("Vidas") && PlayerPrefs.HasKey("UnlockLevel1") 
            && PlayerPrefs.HasKey("UnlockLevel2") && PlayerPrefs.HasKey("UsuarioId")) {
            posX = PlayerPrefs.GetFloat("PosX");
            posY = PlayerPrefs.GetFloat("PosY");
            posZ = PlayerPrefs.GetFloat("PosZ");
            level = PlayerPrefs.GetString("Level");
            vidas = PlayerPrefs.GetInt("Vidas");
            Unlocklevel1 = PlayerPrefs.GetInt("UnlockLevel1");
            Unlocklevel2 = PlayerPrefs.GetInt("UnlockLevel2");
            UsuarioId = PlayerPrefs.GetString("UsuarioId");

        } else {
            PlayerPrefs.SetString("Level", level);
            PlayerPrefs.SetFloat("PosX", posX);
            PlayerPrefs.SetFloat("PosY", posY);
            PlayerPrefs.SetFloat("PosZ", posZ);
            PlayerPrefs.SetInt("Vidas", vidas);
            // PlayerPrefs.SetInt("Vidas", vidas);
            PlayerPrefs.SetInt("UnlockLevel1", Unlocklevel1);
            PlayerPrefs.SetInt("UnlockLevel2", Unlocklevel2);
            PlayerPrefs.SetString("UsuarioId", UsuarioId);
        }
    }
}
