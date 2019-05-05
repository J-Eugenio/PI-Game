using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour{

    public FalaJogo[] falas = new FalaJogo[2];

    private bool dialogoConcluido = false;

    DialogoController dialogoController;

    // Start is called before the first frame update
    void Start()
    {
        dialogoController = FindObjectOfType<DialogoController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().speed = 0;
            if (!dialogoConcluido)
            {
                dialogoController.ProximaFala(falas[0]);
            }
            else
            {
                dialogoController.ProximaFala(falas[1]);
            }

            dialogoConcluido = true;
        }
    }
}
