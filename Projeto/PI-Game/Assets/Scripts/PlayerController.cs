using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public static PlayerController pl;

    public Joystick joystick;

    private Rigidbody2D player;
    private bool facingRight = true;
    private bool jump = false;
    private Animator anim;
    private bool noChao = false;
    private Transform groundCheck;
    private Vector3 posPlayer;
    public GameObject TelaWin;



    void Start () {
        if (!GameManager.check) {
            Salvar();
        }
        player = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");

        transform.position = new Vector3(PlayerData.posX, PlayerData.posY, PlayerData.posZ);

        
    }
	
	// Update is called once per frame
	void Update () {
        
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        

        if (GameManager.gm.GetVida() == true && GameManager.gm.GetEscudo() == true &&
            GameManager.gm.GetVelocidade() == true && GameManager.gm.GetWin() == true) {        
            TelaWin.SetActive(true);
            GameManager.isTimer = false;
            GameManager.gm.AttHudScore();

        }


    }

    public void _jump()
    {
        if (noChao)
        {
            jump = true;
            anim.SetTrigger("Pulo");
        }
    }
    void FixedUpdate() {
        float h = joystick.Horizontal;
        if(h > 0) {
            anim.SetBool("Velocidade", true);
        }else if (h < 0) {
            anim.SetBool("Velocidade", true);
        }
        if (h == 0) {
            anim.SetBool("Velocidade", false);
        }

            player.velocity = new Vector2(h * speed, player.velocity.y);
        //if (joystick.Horizontal >= .2f) {
        //    player.velocity = new Vector2(h * speed, player.velocity.y);
        //} else if (joystick.Horizontal <= -.2f) {
        //    player.velocity = new Vector2(h * speed, player.velocity.y);
        //} else {
        //    player.velocity = new Vector2(0, player.velocity.y);
        //}
        if (h > 0 && !facingRight) {
            Flip();
        } else if (h < 0 && facingRight) {
            Flip();
        }

        if (jump) {
            player.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Salvar()
    {
        PlayerData.posX = transform.position.x;
        PlayerData.posY = transform.position.y;
        PlayerData.posZ = transform.position.z;
        PlayerData.vidas = GameManager.gm.GetVidas();
        PlayerData.level = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("Level", PlayerData.level);
        PlayerPrefs.SetFloat("PosX", PlayerData.posX);
        PlayerPrefs.SetFloat("PosY", PlayerData.posY);
        PlayerPrefs.SetFloat("PosZ", PlayerData.posZ);
        PlayerPrefs.SetInt("Vidas", PlayerData.vidas);
    }
    private void RetornaVelocidadeAnterior() {
        StartCoroutine(VelocidadeAnterior());

    }
    IEnumerator VelocidadeAnterior() {
        yield return new WaitForSeconds(8);
        int VeloAnterior = 5;
        speed = VeloAnterior;
    }
    private void OnTriggerEnter2D(Collider2D velocidade)
    {
        if (velocidade.gameObject.CompareTag("velocidade"))
        {
            GameManager.gm.SetVelocidade(true);
            speed = 8;
            Destroy(velocidade.gameObject);
            RetornaVelocidadeAnterior();
        }
        
    }

}
