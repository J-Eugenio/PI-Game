using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Checkpoint"))
        {
            PlayerData.posX = transform.position.x;
            PlayerData.posY = transform.position.y;
            PlayerData.posZ = transform.position.z;
            PlayerData.vidas = GameManager.gm.GetVidas();
            PlayerData.level = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("Level", PlayerData.level);
            PlayerPrefs.SetFloat("PosX", PlayerData.posX);
            PlayerPrefs.SetFloat("PosY", PlayerData.posY);
            PlayerPrefs.SetFloat("PosZ", PlayerData.posZ);
            PlayerPrefs.SetInt("Vidas", PlayerData.vidas);
            GameManager.check = true;
        }
    }
}