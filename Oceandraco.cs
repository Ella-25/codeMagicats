using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //manipula as cenas do jogo

public class Oceandraco : MonoBehaviour
{
    Rigidbody2D rbOceandraco; //variável do dragão com rigidbody
    [SerializeField] float speed = 2f;
    [SerializeField] Transform point1, point2;
    [SerializeField] LayerMask layer;
    [SerializeField] bool IsColliding;

    private void Awake() //dentro deste método é armazenado o componente rigidbody dentro da variável rbOceandraco
    {
        rbOceandraco = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rbOceandraco.velocity = new Vector2(speed, rbOceandraco.velocity.y);

        IsColliding = Physics2D.Linecast(point1.position, point2.position, layer); //se o personagem colidir com algo o iscolliding fica verdadeiro

        if (IsColliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1; //quando colide com o objeto de colisão, a velocidade é negativada
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //se a colisão do objeto de jogo for com o player, pega componentes de animação e rigidibody (leis da física)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Morto"); //parâmetro trigger -> gatilho
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //com a colisão tira a velocidade do player
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false; //desabilita o componente de capsula, não tendo mais colisão após colidir a primeira vez
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; //atribuindo tipo cinemático ao player para não sofrer com gravidade ou outras forças
            collision.gameObject.GetComponent<MovimentoPlayer>().enabled = false; //desabilitar o script player
            Invoke("LoadScene", 1.6f); //1s antes de recarregar a próxima cena
        }
    }

    void LoadScene() //acessa função carregar cena -> game over
    {
        SceneManager.LoadScene("GameOver");
    }
}
