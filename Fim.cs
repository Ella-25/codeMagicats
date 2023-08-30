using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importa biblioteca de cena

public class Fim : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //se a colisão for com a tag player, carrega a tela final
        {
            SceneManager.LoadScene("Fim");
        }
    }
}
