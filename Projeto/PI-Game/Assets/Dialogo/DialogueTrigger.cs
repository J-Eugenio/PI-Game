using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public GameObject showPuzzles;
    public int nExec = 1;

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
            showPuzzles.SetActive(true);
        }



    }

}
