using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float velocidade = 0.1f;
    public Renderer backgroud;

    void Start()
    {
        
    }

   
    void Update()
    {
        Vector2 offset = new Vector2(velocidade * Time.deltaTime, 0);
        backgroud.material.mainTextureOffset += offset;
    }
}
