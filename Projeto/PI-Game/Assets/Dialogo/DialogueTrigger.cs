using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public GameObject showPuzzles;
    public GameObject plataforma;
    public int nExec = 1;
    public bool AtivarPuzzle = false;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && nExec == 1)
        {
            nExec = 0;
            TriggerDialogue();
            GameManager.gm.ativarInimigos = false;
            if (AtivarPuzzle) {
                showPuzzles.SetActive(true);
                plataforma.SetActive(true);
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
     
    }
    }
