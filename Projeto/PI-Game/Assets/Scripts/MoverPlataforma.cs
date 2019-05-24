using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public GameObject[] locais;
    public int destinoInicial = 0;
    public float velocidade = 10;
    public bool comecarInvertido;
    public bool reiniciarSequencia;

    int localAtual = 0;
    bool inverter = false;

    void Start()
    {
        if (destinoInicial < locais.Length)
        {
            localAtual = destinoInicial;
        }
        else
        {
            localAtual = 0;
        }
        //
        if (comecarInvertido == true)
        {
            inverter = true;
        }
    }

    void Update()
    {
        if (inverter == false)
        {
            if (Vector3.Distance(transform.position, locais[localAtual].transform.position) < 0.1f)
            {
                if (localAtual < locais.Length - 1)
                {
                    localAtual++;
                }
                else
                {
                    if (reiniciarSequencia == true)
                    {
                        localAtual = 0;
                    }
                    else
                    {
                        inverter = true;
                    }
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, locais[localAtual].transform.position, velocidade * Time.deltaTime);
        }
        else
        {
            if (Vector3.Distance(transform.position, locais[localAtual].transform.position) < 0.1f)
            {
                if (localAtual > 0)
                {
                    localAtual--;
                }
                else
                {
                    if (reiniciarSequencia == true)
                    {
                        localAtual = locais.Length - 1;
                    }
                    else
                    {
                        inverter = false;
                    }
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, locais[localAtual].transform.position, velocidade * Time.deltaTime);
        }
    }
}
