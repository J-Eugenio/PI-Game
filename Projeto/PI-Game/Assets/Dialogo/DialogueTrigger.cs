using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public GameObject showPuzzles;
    public GameObject plataforma;

    
    
    public bool AtivarPuzzle = false;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            
            Debug.Log("Aqui");
            
            TriggerDialogue();
            GameManager.gm.ativarInimigos = false;
            plataforma.SetActive(true);
            

           
            

            if (AtivarPuzzle) {
                showPuzzles.SetActive(true);
                
            }            
        }
    }

    }
