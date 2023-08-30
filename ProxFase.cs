using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importa��o de biblioteca de cena

public class ProxFase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //se a colis�o for com a tag player, carrega a segunda fase
        {
            SceneManager.LoadScene("Fase2");
        }
    }
}
