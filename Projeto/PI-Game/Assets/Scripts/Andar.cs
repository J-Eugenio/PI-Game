using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour
{
    public bool attack = false;
    public float velocidade;
    public bool plantaforma = false;
    Rigidbody2D ini;
    bool facingRight = false;
    bool noChao = false;
    public bool NaPlantaforma = false;
    Transform groundCheck;
    Animator ani;
    public float jumpForce = 700;

    void Start()
    {
        ini = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");
        ani = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (NaPlantaforma)
        {
            noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        }
        else
        {
            noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("GroundInimigo"));
        }


        if (plantaforma)
        {
            if (!noChao)
            {
                velocidade *= -1;
            }
        }
        else
        {
            if (noChao)
            {
                velocidade *= -1;
            }
        }

    }

    void FixedUpdate()
    {
        if (true)
        {
            ini.velocity = new Vector2(velocidade, ini.velocity.y);//faz andar
        }
        if (velocidade > 0 && facingRight)
        {
            Flip();
        }
        else if (velocidade < 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}