using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string level;
    private GameObject[] datas;

    void Awake()
    {
        datas = GameObject.FindGameObjectsWithTag("DATA");
        if(datas.Length >= 2)
        {
            Destroy(datas[0]);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
}
