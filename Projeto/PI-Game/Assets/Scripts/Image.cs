using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image : MonoBehaviour
{
    [SerializeField] private Image imagem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imagem.enabled = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            imagem.enabled = false;
        }

        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
