using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //manipula as cenas do jogo

public class Oceandraco : MonoBehaviour
{
    Rigidbody2D rbOceandraco; //vari�vel do drag�o com rigidbody
    [SerializeField] float speed = 2f;
    [SerializeField] Transform point1, point2;
    [SerializeField] LayerMask layer;
    [SerializeField] bool IsColliding;

    private void Awake() //dentro deste m�todo � armazenado o componente rigidbody dentro da vari�vel rbOceandraco
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
            speed *= -1; //quando colide com o objeto de colis�o, a velocidade � negativada
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //se a colis�o do objeto de jogo for com o player, pega componentes de anima��o e rigidibody (leis da f�sica)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Morto"); //par�metro trigger -> gatilho
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //com a colis�o tira a velocidade do player
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false; //desabilita o componente de capsula, n�o tendo mais colis�o ap�s colidir a primeira vez
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; //atribuindo tipo cinem�tico ao player para n�o sofrer com gravidade ou outras for�as
            collision.gameObject.GetComponent<MovimentoPlayer>().enabled = false; //desabilitar o script player
            Invoke("LoadScene", 1.6f); //1s antes de recarregar a pr�xima cena
        }
    }

    void LoadScene() //acessa fun��o carregar cena -> game over
    {
        SceneManager.LoadScene("GameOver");
    }
}
