using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite placa;
    public Sprite placaChecada;
    private SpriteRenderer checkpointSpriteRenderer;



    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = placaChecada;
         
        }

        
    }

}
