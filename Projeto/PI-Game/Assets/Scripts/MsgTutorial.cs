using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgTutorial : MonoBehaviour
{
    public Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
            rend.enabled = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
            rend.enabled = false;
    }
}
