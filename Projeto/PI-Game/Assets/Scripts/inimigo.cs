using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float velocidade;
    public bool plantaforma = false;
    Rigidbody2D ini;
    bool facingRight = false;
    bool noChao = false;
    Transform groundCheck;

    public float jumpForce = 700;
    void Start()
    {
        ini = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");
    }

    void Update()
    {
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (plantaforma) {
            if (!noChao) {
                velocidade *= -1;
            }
        } else {
            if (noChao) {
                velocidade *= -1;
            }
        }
    }

    void FixedUpdate() {
        ini.velocity = new Vector2(velocidade, ini.velocity.y);
        if(velocidade > 0 && facingRight) {
            Flip();
        }else if( velocidade < 0 && !facingRight) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.CompareTag("Player")) {
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes) {
                box.enabled = false;
            }

            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            velocidade = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 2);
        }
    }
}
