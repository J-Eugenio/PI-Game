using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;//velocidade do personagem
    public float jumpForce;//forã do pulo
    public static PlayerController pl;//objeto do player
    public GameObject cr;
    public CharacterController2D controller;

    

    private Rigidbody2D player;
    private bool facingRight = true;
    private bool jump = false;
    private Animator anim;//animação do personagem
    private bool noChao = false;
    private Transform groundCheck;//objeto que verifica se o player esta no chão
    private Vector3 posPlayer;//posição X,Y,Z do personagem
    [SerializeField]
    private GameObject TelaWin;
    [SerializeField]
    private GameObject[] Stars = new GameObject[3];//guarda as estrelas do score
    //usado no calculo para o personagem se mover
    float horizontalMove = 0f;
    int raw = 0;//valor faz o personagem ir para esquerda(-1), direita(1) ou fica parado(0)
    [SerializeField]
    private GameObject somFase;
    [SerializeField]
    private GameObject somFaseFinal;
    private void Awake()
    {
        
    }
    void Start () {     
        if (!GameManager.check) {
            Salvar();
            GameManager.gm.ScoreTotal = 0;
            GameManager.gm.ZeraStatusItens();
            
        }
        player = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        transform.position = new Vector3(PlayerData.posX, PlayerData.posY, PlayerData.posZ);   
    }
	
	// Update is called once per frame
	void Update () {
        
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //faz o personagem se mover
        horizontalMove = raw * speed;
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        //requisitos do score
        if (GameManager.gm.GetVida() == true && GameManager.gm.GetEscudo() == true &&
            GameManager.gm.GetVelocidade() == true && GameManager.gm.GetWin() == true) {        
            TelaWin.SetActive(true);
            if(GameManager.gm.ScoreTotal >= 2500) {
                Stars[0].SetActive(true);
                Stars[1].SetActive(true);
                Stars[2].SetActive(true);
            }else if (GameManager.gm.ScoreTotal >= 1800 && GameManager.gm.ScoreTotal < 2500) {
                Stars[0].SetActive(true);
                Stars[1].SetActive(true);
                Stars[2].SetActive(false);
            }else if (GameManager.gm.ScoreTotal >= 1000 && GameManager.gm.ScoreTotal < 1800) {
                Stars[0].SetActive(true);
                Stars[1].SetActive(false);
                Stars[2].SetActive(false);
            } else {
                Stars[0].SetActive(false);
                Stars[1].SetActive(false);
                Stars[2].SetActive(false);
            }

            GameManager.gm.AttHudScore();
            somFase.SetActive(false);
            somFaseFinal.SetActive(true);
        } else {
            somFase.SetActive(true);
            somFaseFinal.SetActive(false);
        }


    }
    // função do pulo
    public void _jump()
    {
        if (noChao)
        {
            jump = true;
            anim.SetTrigger("Pulo");
        }
    }

    void FixedUpdate() {
        if (jump) {
            player.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }
    //faz o personagem virar para os lados
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //salvar os dados do jogo atual
    public void Salvar()
    {
        Debug.Log("Salvaou");
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
    //retorna a velocidade anterior dps que o efeito do item acabar
    private void RetornaVelocidadeAnterior() {
        StartCoroutine(VelocidadeAnterior());

    }
    IEnumerator VelocidadeAnterior() {
        yield return new WaitForSeconds(8);
        int VeloAnterior = 30;
        speed = VeloAnterior;
    }
    //Item Velocidade e sua velocidade
    private void OnTriggerEnter2D(Collider2D velocidade)
    {
        if (velocidade.gameObject.CompareTag("velocidade"))
        {
            
            GameManager.gm.SetVelocidade(true);
            speed = 40;
            Destroy(velocidade.gameObject);
            RetornaVelocidadeAnterior();
        }      
    }

    public void FrenteDown() {
        raw = 1;
        anim.SetBool("Velocidade", true);
    }
    public void FrenteUp() {
        raw = 0;
        anim.SetBool("Velocidade", false);
    }

    public void TrazDown() {
        raw = -1;
        anim.SetBool("Velocidade", true);
    }
    public void TrazUp() {
        raw = 0;
        anim.SetBool("Velocidade", false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlataformaMovel")
        {
            transform.parent = collision.transform;
            
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlataformaMovel")
        {
            transform.parent = null;
        }
    }
}
