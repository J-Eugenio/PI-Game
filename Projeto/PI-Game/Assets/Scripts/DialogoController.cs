using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogoController : MonoBehaviour
{

    public GameObject painelDeDialogo;

    public Text falaJogo;

    public GameObject resposta;

    private bool falaAtiva = false;

    FalaJogo falas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && falaAtiva)
        {
            if (falas.respostas.Length > 0)
                MostrarRespostas();
          
            else
            {
                falaAtiva = false;
                painelDeDialogo.SetActive(false);
                falaJogo.gameObject.SetActive(false);
                FindObjectOfType<PlayerController>().speed = 5;
            }
        }
    }

    void MostrarRespostas()
    {
        falaJogo.gameObject.SetActive(false);
        falaAtiva = false;

        for(int i = 0; i < falas.respostas.Length; i++)
        {
            GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            tempResposta.GetComponent<AnswerButton>().Setup(falas.respostas[i]);
        }
    }

    public void ProximaFala(FalaJogo fala)
    {
        falas = fala;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogo.SetActive(true);
        falaJogo.gameObject.SetActive(true);

        falaJogo.text = falas.fala;
    }

    void LimparRespostas()
    {
        AnswerButton[] buttons = FindObjectsOfType<AnswerButton>();
        foreach(AnswerButton button in buttons)
        {
           Destroy(button.gameObject);
        }
    }
}
