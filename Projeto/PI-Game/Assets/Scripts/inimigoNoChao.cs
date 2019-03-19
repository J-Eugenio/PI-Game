using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoNoChao: MonoBehaviour {
    public float velocidade2;
    Rigidbody2D iniNoChao;
    bool facingRight2 = false;
    bool noChao2 = false;
    Transform groundCheck2;

    public float jumpForce2 = 700;
    void Start() {
        iniNoChao = gameObject.GetComponent<Rigidbody2D>();
        groundCheck2 = transform.Find("EnemyGroundCheck");
    }

    void Update() {
        noChao2 = Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground"));
        if (noChao2) {
            velocidade2 *= -1;
        }
    }

    void FixedUpdate() {
        iniNoChao.velocity = new Vector2(velocidade2, iniNoChao.velocity.y);
        if (velocidade2 > 0 && facingRight2) {
            flip();
        } else if (velocidade2 < 0 && !facingRight2) {
            flip();
        }
    }

    void flip() {
        facingRight2 = !facingRight2;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.CompareTag("Player")) {
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes) {
                box.enabled = false;
            }

            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce2));
            velocidade2 = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 2);
        }
    }
}
