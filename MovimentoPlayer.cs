using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; //manipula��o de cenas

public class MovimentoPlayer : MonoBehaviour
{
    Rigidbody2D rbPlayer; //vari�vel do componente rigidbody
    //[SerializeField] � exibida apenas no inspetor
    [SerializeField] float speed = 5f; //vari�vel velocidade
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isJump; //verifica se o player est� pulando ou n�o
    [SerializeField] bool inFloor = true; //verifica se o player est� no ch�o ou n�o
    [SerializeField] Transform groundCheck; //referencia objeto de checagem do ch�o
    [SerializeField] LayerMask groundLayer; //m�scara de camada espec�fica

    private void Awake() //m�todo chamado antes do start; armazena o componente rigidbody
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update() //adi��o de jump e linha de colis�o
    {
        inFloor = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer); //Physics2D classe geral. Linha que liga o inicio ao fim. groundLayer verifica a colis�o da linha
        Debug.DrawLine(transform.position, groundCheck.position, Color.blue);

        if (Input.GetButtonDown("Jump") && inFloor)
        {
            isJump = true;
        }
        else if (Input.GetButtonUp("Jump") && rbPlayer.velocity.y > 0)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, rbPlayer.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate() //puxa m�todos
    {
        Move();
        JumpPlayer();
    }

    void Move()
    {
        //vari�vel para movimento horizontal
        float xMove = Input.GetAxis("Horizontal"); //atribuir classe input
        
        //acessar propriedade velocidade
        rbPlayer.velocity = new Vector2(xMove * speed, rbPlayer.velocity.y);

        if (xMove > 0)//verifica se � maior que 0 (virado p/ lado positivo - 0y) ou se � menor (virado p/ lado negativo - 180y)
        {
            transform.eulerAngles = new Vector2(0, 0); //propriedade euler permite criar rota��es
        }
        else if (xMove < 0)
        {
            transform.eulerAngles = new Vector2(0, 180); //vira o player pro lado esquerdo
        }
    }

    void JumpPlayer() //quando o player est� pulando
    {
        if (isJump)
        {
            rbPlayer.velocity = Vector2.up * jumpForce;
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //morte oceandraco
    {
        if (collision.gameObject.tag == "Inimigo") //se tiver colis�o com o inimigo
        {
            rbPlayer.velocity = Vector2.zero; //zera sua velocidade
            rbPlayer.AddForce(Vector2.up * 5, ForceMode2D.Impulse); //adiciona for�a apenas ao eixo y (vertical). Ao colidir com o inimigo da um pequeno impulso
            collision.gameObject.GetComponent<SpriteRenderer>().flipY = true; //ele vira o inimgo de cabe�a para baixo
            collision.gameObject.GetComponent<Oceandraco>().enabled = false; //desabilita o script do inimigo
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false; //desabilita a capsula do inimigo
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false; //desabilita a caixa de colis�o
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; //pega o corpo rigido e transforma em cinematica com tipo de corpo
            Destroy(collision.gameObject, 1f); //destr�i ap�s 1s
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Fase1");
    }
}
