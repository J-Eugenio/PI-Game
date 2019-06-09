using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPuzzles : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject puzzleController;
    [SerializeField]
    private GameObject cronometro;
    private void OnTriggerEnter2D(Collider2D collision2D) {
        if (collision2D.gameObject.CompareTag("Player")) {
            puzzle.SetActive(true);
            puzzleController.SetActive(true);
            cronometro.SetActive(true);
            GameManager.gm.ativarTime = false;
            GameManager.gm.ativarInimigos = false;
        }
    }
}
